// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    var span = document.createElement("h4");
    span.innerHTML = "Please Wait...";
    var sweet_loader = document.createElement("div");
    sweet_loader.classList.add("sweet_loader");
    sweet_loader.innerHTML = '<svg viewBox="0 0 140 140" width="140" height="140"><g class="outline"><path d="m 70 28 a 1 1 0 0 0 0 84 a 1 1 0 0 0 0 -84" stroke="rgba(0,0,0,0.1)" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round"></path></g><g class="circle"><path d="m 70 28 a 1 1 0 0 0 0 84 a 1 1 0 0 0 0 -84" stroke="#71BBFF" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-dashoffset="200" stroke-dasharray="300"></path></g></svg>';
    const container = document.createElement("div");
    container.id = 'spinner';
    // You could also use container.innerHTML to set the content.
    container.append(span);
    container.append(document.createElement("br"));
    container.append(sweet_loader);
    SuccessNotification = (description) => {
        swal({
            title: 'Success',
            text: description,
            icon: "success",
            buttons: {
                cancel: false,
                confirm: true,
            },
            dangerMode: false,
        })
    }
    WarningNotification = (description) => {
        swal({
            title: 'Warning',
            text: description,
            icon: "warning",
            showCancelButton: false,
            dangerMode: false,
        })
    }
    ErrorNotification = (description) => {
        swal({
            title: 'Error',
            text: description,
            icon: "error",
            buttons: {
                cancel: false,
                confirm: true,
            },
            dangerMode: true,
        })
    }

    getDatatable = (cols) => {
        var dt = $('.data-table').DataTable({
            dom: "rt<'row'<'col-md-6 col-xs-12'i><'col-md-2 col-xs-12'l><'col-md-4 col-xs-12'p>>",
            responsive: true,
            serverSide: true,
            pagingType: "simple_numbers",
            processing: true,
            language: {
                processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>Loading...',
                emptyTable: 'No record found'
            },
            order: [0, "asc"],
            lengthMenu: [10, 25, 50, 100, 250, 500],
            filter: true,
            columns: cols,
        });
        return dt;
    }
    LoadingSpinner = () => {
        swal({
            content: container,
            buttons: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    ValidatePhone = (input) => {
        let str = input.value;
        if (parseInt(str[3]) != 3 || parseInt(str[4]) > 4) {
            $('#PhoneNumber').val("");
        }
    }
    $('body').delegate('.prodQuan', 'change keypress', function (event) {
        let selectCheck = this.value == document.getSelection().toString();
        if (!selectCheck && (event.keyCode == 45 || event.keyCode == 46 || this.value.length == 4 || event.keyCode == 109 || event.keyCode == 107 || event.keyCode == 69)) {
            event.preventDefault();
        }
        if (this.value > 0) {
            $('#variantValidation').html("");
        }
    })
    $('body').delegate('.prodQuan', 'keyup', function (e) {
        this.value = parseInt(this.value);
    })

    $('body').delegate('.percentage', 'keypress', function (event) {
        if (event.keyCode == 45) {
            event.preventDefault();
        }
    });

    $('body').delegate('.percentage', 'keyup', function (event) {
        if (this.value.length > 3) {
            var num = parseFloat(this.value);
            this.value = num.toFixed(2)
        }
        if (this.value > 100) {
            this.value = 100;
        }
    });
    $('body').delegate('.logOffBtn', 'click', function () {
        localStorage.clear();
    })
    $(document).on('click', 'ul.menu-scroll', function (event) {
        event.stopPropagation();
    })
    $(document).on('select2:open', () => {
        document.querySelector('.select2-search__field').focus();
    });
    GetErrorMsg = (error) => {
        let errorMsg = ``;
        if (error != "") {
            let errors = error.split(',');
            let className = errors.length > 3 ? "tooltip-ul text-left" : "tooltip-ul1 text-left"
            let bullets = ``;
            errors.forEach((val) => {
                if (val == 'Deleted')
                    val = 'Entity is deleted but will be reactivated.';
                bullets += `<li>${val}</li>`;
            })
            errorMsg = `<b>Errors</b>
                        <ul class=${className}>
                            ${bullets}
                         </ul>`
        }
        else
            errorMsg = `---`;
        return errorMsg;
    }
});