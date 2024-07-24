$(document).ready(function () {
    $("#location").select2({
        width: '100%'
    });
    $("#customer").select2({
        width: '100%'
    });
    $("#product").select2({
        width: '100%'
    });
    $("#variant").select2({
        width: '100%'
    });
    $("#route").select2({
        width: '100%'
    });
    var forceUpdate = false;
    GetCustomer = () => {
        $.ajax({
            url: '/Discount/GetCustomers',
            method: 'GET',
            type: 'get',
            data: { Id: $("#location").val() },
            success: function (response) {
                $("#customer").empty()
                response.customers.forEach((element) => {
                    $("#customer").append(
                        `<option value="${element.id}">${element.custName}</option>`
                    )
                })
                $('#custError').html("");
            },
            error: function (err) {
                console.log(err)
            }
        })
    }
    GetSalesPerson = () => {
        $.ajax({
            url: '/Discount/GetSalesPerson',
            method: 'GET',
            type: 'get',
            data: { Id: $("#route").val() },
            success: function (response) {
                $("#salesperson").empty()
                $("#salesperson").val(response.name);
            },
            error: function (err) {
                console.log(err)
            }
        })
    }

    $("#AddProduct").change(function () {
        if ($("#AddProduct").is(":checked")) {
            $("#product").removeAttr("disabled");
            $("#variant").removeAttr("disabled");
        }
        else {
            $("#product").attr("disabled", "disabled");
            $("#variant").attr("disabled", "disabled");
            $("#discount").removeAttr("max").val("");
        }
    })

    GetVariant = () => {
        $.ajax({
            url: '/Discount/GetVariant',
            method: 'GET',
            type: 'get',
            data: { Id: $("#product").val() },
            success: function (response) {
                $("#variant").empty()
                if (response.variants.length > 0) {
                    response.variants.forEach((element) => {
                        $("#variant").append(
                            `<option value="${element.id}">${element.name}</option>`
                        )
                    })
                }
                else {
                    $("#variant").append(
                        `<option value="${$("#product").val()}">---</option>`
                    )
                }
                $('#variantError').html("");
                GetMaxPrice();
            },
            error: function (err) {
                console.log(err)
            }
        })
    }

    ApplyDiscount = () => {
        let txt = "Are you sure, you want to set the discount?"
        if ($("#ApplyDiscountForm").valid()) {
            swal({
                text: txt,
                icon: "warning",
                buttons: true,
                dangerMode: true,
            }).then((Ok) => {
                if (Ok) {
                    ApplyDiscountAjax();
                }
            });
        }
        else {
            $("#location-error").detach().appendTo("#locError");
            $("#customer-error").detach().appendTo("#custError");
            $("#product-error").detach().appendTo("#prodError");
            $("#variant-error").detach().appendTo("#variantError");
            $("#route-error").detach().appendTo("#routeError");
        }
    }
    ApplyDiscountAjax = () => {
        var form = $("#ApplyDiscountForm").serialize() + "&force=" + forceUpdate;
        $.ajax({
            url: '/Discount/AddDiscount',
            method: 'POST',
            type: 'post',
            beforeSend: LoadingSpinner(),
            data: form,
            success: function (response) {
                forceUpdate = false;
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
                if (err.status == 409) {
                    swal({
                        text: err.responseJSON.message + " Do you want to update/reactivate?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    }).then((OK) => {
                        if (OK) {
                            forceUpdate = true;
                            ApplyDiscountAjax();
                        }
                    })
                }
                else {
                    ErrorNotificaton(err.responseJSON.message)
                }
            }
        })
    }
    $('body').delegate("#IsPercentage","change keydown",function () {
        if ($("#IsPercentage").is(":checked")) {
            $("#discount").attr("max", "99").addClass("percentage")
        }
        else {
            if ($("#AddProduct").is(":checked")) {
                if ($("#price").val() == "")
                    $("#discount").removeAttr("max").removeClass("percentage")
                else
                    $("#discount").removeClass("percentage").attr("max", $("#price").val())
            }
            else
                $("#discount").removeAttr("max").removeClass("percentage")
            $("#discount").addClass("discount");
        }
        $("#discount").val("");
        $("#discount-error").html("");
    })
    $('body').delegate(".discount", "change keydown", function (e) {
        if (e.keyCode != 8 && (e.keyCode == 109 || this.value.length > 3 || e.keyCode == 110)) {
            e.preventDefault()
            if (parseInt(this.value) > 9999)
                this.value = 9999;
        }
    })

    RemoveValidation = (id) => $(`#${id}`).html("");

    GetMaxPrice = () => {
        $.ajax({
            url: '/Discount/GetPrice',
            type: 'GET',
            method: 'get',
            data: { id: $("#variant option:selected").val() },
            success: function (response) {
                $("#price").val(response.price);
                $("#discount").attr("max", response.price);
            },
            error: function (err) {
                console.log(err.responseJSON.message);
            }
        })
    }
})