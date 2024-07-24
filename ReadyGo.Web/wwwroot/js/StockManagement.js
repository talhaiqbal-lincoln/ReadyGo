$(document).ready(function () {
    $("#route").select2({
        width: '100%'
    });
    $("#vehicle").select2({
        width: '100%'
    });
    $("#category1").select2({
        width: '100%'
    });
    GetItems = (id,flag) => {
        var URL = flag == "Edit" ? "../../Stock/GetProduct" : "../Stock/GetProduct";
        $.ajax({
            url: URL,
            method: "GET",
            type: "json",
            data: {
                cat_id: $(`#category${id}`).val()
            },
            success: function (data) {

                $(`#item${id}`).empty();
                if (data.length == 0) {
                    $("#productVariant").html(`<div class="col-md-10">
                                    <label class="required">Quantity: </label>
                                    <div class="row">
                                        <div class="col-md-4" style="padding-left:0px"><input dir="rtl" id="prodQuantity" type="number" min="0" max="9999" class="form-control prodQuan text-right" /></div>
                                        <div class="submit-btn col-md-2"><button class="btn btn-default" onclick="ApplyChanges('${id}',null)">Apply</button></div>
                                    </div>
                                </div>`)

                }
                else {
                    let innerHtml = "";
                    let optionId = 1;
                    data.forEach(element => {
                        innerHtml += `<li class="row col-md-12"><input id="item${id}checkbox${optionId}" value="${element.id}" type="hidden" style="margin-top:12px;"><p class="col-md-9 col-xs-9" id="item${id}Text${optionId}" style="margin-top:10px;font-size:13px">${element.name}</p> <input dir="rtl" type="number" min="0" max="9999" id="item${id}input${optionId}" value="0" style="margin-top:3px;border:1px solid #ddd" class="col-md-3 col-xs-3 form-control prodQuan text-right" type="text"></li>`;
                        optionId++;
                    })
                    innerHtml += `<li style="padding-top:3px" class="col-md-12 fixed"><button class="btn btn-default alignright" onclick="ApplyChanges('${id}','${optionId}')">Apply</button></li>`;

                    $("#productVariant").html(`<div class="col-md-10">
                                        <label class="required">Item & Quantity: </label>
                                        <div class="dropdown">
                                            <button id="item1Button" class="btn btn-default form-control dropdown-toggle" type="button" data-toggle="dropdown">
                                                <span id="item1ButtonTitle">Select Variant </span>
                                                <span class="caret"></span>
                                            </button>

                                            <ul class="dropdown-menu menu-scroll" id="item1" style="padding-top:2%;width:100%;position:inherit!important">
                                                ${innerHtml}
                                            </ul>

                                            <input type="text" hidden id="item1Value" />
                                        </div>
                                    </div>`)

                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    };
    AssignStock = (flag) => {
        var prod = [];
        var RouteId = $('#route').val();
        var VehicleId = $('#vehicle').val();
        var DriverName = $('#driverName').val();
        if (flag == "Edit") {
            var Id = $('#Id').val();
        }
        var URL = flag == "Edit" ? "../../Stock/EditAssignStock" : "../Stock/AssignStocktoRoute";
        var txt = flag == "Edit" ? "Are you sure, you want to update the assigned stock?" : "Are you sure, you want to assign this stock to the salesperson?";
        if ($("#transferStockForm").valid()) {
            let stockTable = document.getElementById("stockTableBdy").rows;
            for (let i = 0; i < stockTable.length; i++) {
                var item = {
                    Quantity: stockTable[i].querySelectorAll('input')[0].value,
                    Id: stockTable[i].cells[4].innerHTML,
                }
                prod.push(item);
            }

            if (prod.length == 0) {
                if ($('#category1 option:selected').val() == "NA") {
                    $("#productValidation").html("The Product field is required.");
                }
                if ($("#productVariant").html() != "") {
                    $("#variantValidation").html("The Quantity field is required.");
                }
            }
            else {
                swal({
                    text: txt,
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                }).then((willDelete) => {
                    if (willDelete) {
                        $.ajax({
                            url: URL,
                            method: "POST",
                            type: "post",
                            beforeSend: LoadingSpinner(),
                            data: {
                                RouteId: RouteId,
                                VehicleId: VehicleId,
                                Products: prod,
                                DriverName: DriverName,
                                Id: Id
                            },
                            success: function (response) {
                                swal.close();
                                swal({
                                    title: 'Success',
                                    text: response.message,
                                    icon: "success",
                                    closeOnClickOutside: false
                                }).then((ok) => {
                                    if (ok) {
                                        let url = document.referrer;
                                        window.location.href = url;
                                    }
                                })
                            },
                            error: function (err) {
                                swal.close();
                                ErrorNotification(err.responseJSON.message);
                            }
                        })
                    }
                });
            }
        }
        else {
            $("#vehicle-error").detach().appendTo("#vehicleMsg").addClass('text-danger');
            $("#route-error").detach().appendTo("#routeMsg").addClass('text-danger');
            $("#driverName-error").detach().appendTo("#driverMsg").addClass('text-danger');
            $("#productValidation").html("The Product field is required.");
        }
    };

    ApplyChanges = (rowId, prodRange) => {
        if ($("#route").val() != null) {
            if (prodRange != null) {
                for (let i = 1; i < prodRange; i++) {
                    if ($(`#item1input${i}`).val() != "" && $(`#item1input${i}`).val() != "0") {
                        let prodName = $(`#item1Text${i}`).html();
                        let prodId = $(`#item1checkbox${i}`).val();
                        let ind = GetRow(prodId);
                        UpdateTable(prodName, prodId, $(`#item1input${i}`).val(), ind);
                    }
                }
            }
            else {
                let rowValue = [];
                if ($(`#prodQuantity`).val() != "" && $(`#prodQuantity`).val() != "0") {
                    let prodName = $(`#category1 option:selected`).text();
                    let prodId = $(`#category1 option:selected`).val();
                    let ind = GetRow(prodId);
                    UpdateTable(prodName, prodId, $("#prodQuantity").val(), ind);
                }
            }
        }
        else {
            ErrorNotification("Please select route")
        }
        $("#item1Button").click();
    };
    GetRow = (prodId) => {
        let routeId = $("#route option:selected").val();
        var index = -1;
        var x = document.getElementById("stockTableBdy").rows;
        for (var i = 0; i < x.length; i++) {
            if (x[i].cells[3].innerHTML == routeId && x[i].cells[4].innerHTML == prodId)
                index = i;
        }
        return index;
    }
    GetSalesPerson = (flag) => {
        var URL = flag == "Edit" ? "../../Stock/GetSalesPerson" : "../Stock/GetSalesPerson";
        $.ajax({
            url: URL,
            type: "get",
            method: "get",
            data: { id: $("#route").val() },
            success: function (response) {
                $("#routeSp").val(response.spName)
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
    GetDriver = () => {
        let vehicleId = $('#vehicle').val();
        $.ajax({
            url: '/Stock/GetDriver',
            type: 'get',
            method: 'get',
            data: { id: vehicleId },
            success: function (response) {
                $("#driverName").val(response.driverName);
                $("#driverMsg").html("");
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
    UpdateTable = (prod, prodId, quant, ind) => {
        let routeId = $("#route option:selected").val();
        if (ind != -1) {
            let table = document.getElementById("stockTableBdy").rows;
            let quantInput = table[ind].querySelectorAll('input')[0];
            quantInput.value = quant;
        }
        else {
            if ($("#category1 option:selected").text() == prod) {
                product = prod;
                variant = "---";
            }
            else {
                product = $("#category1 option:selected").text();
                variant = prod;
            }
            innerhtml = `<tr>
                                    <td>${product}</td>
                                    <td>${variant}</td>
                                    <td><input dir="rtl" type="number" class="prodQuan text-right" min="1" value="${quant}"></td>
                                    <td hidden>${routeId}</td>
                                    <td hidden>${prodId}</td>
                                    <td>
                                        <a id="${prodId}" onclick="DeleteStockRow('${prodId}')"><i class="fa fa-trash" style="color:#c30e0e;font-size:20px"></i></a>
                                    </td>
                                </tr>`;
            $("#stockTableBdy").append(innerhtml);
        }
    }
    DeleteStockRow = (id) => $(`#${id}`).parent().parent().remove();
    RemoveValidation = (id) => {
        $(`#${id}`).html("");
    }

    $('#stockTableBdy').delegate('input[type="number"]', 'change keyup', function (event) {
                if (this.value < 1) {
                    this.value = "";
                }
            })
})