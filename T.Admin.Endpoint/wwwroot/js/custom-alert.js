const confirmHotelTitleMessage = "از ثبت این هتل مطمئن هستید؟";
const confirmHotelTextMessage = "در صورت ثبت این هتل به لیست هتل های وبسایت اضافه می شود !";
const rejectHotelTitleMessage = "از رد کردن این هتل مطمئن هستید؟";
const rejectHotelTextMessage = "در صورت رد کردن، امکان تغییر وضعیت وجود ندارد !";
const deleteHotelTitleMessage = "از حذف این هتل مطمئن هستید؟"
const deleteHotelTextMessage = "در صورت حذف این هتل؛ این هتل از لیست هتل های موجود در سایت حذف می شود !";
const successOperationMessage = "عمبیات با موفقیت انجام شد !";
const failedOperationMessage = "عمبیات ناموفق بود !";

function ShowAlertHotel(id, action) {
    var title, text;
    if (action === "Confirm") {
        title = confirmHotelTitleMessage;
        text = confirmHotelTextMessage;
    } else if (action === "Reject") {
        title = rejectHotelTitleMessage;
        text = rejectHotelTextMessage;
    } else if (action === "Delete") {
        title = deleteHotelTitleMessage;
        text = deleteHotelTextMessage;
    }
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'لغو'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/HotelManagement/${action}?id=${id}`,
                type: "post"
                , success: function (response) {
                    if (response.status === "success") {
                        toastr["success"](successOperationMessage)
                        toastr.options = {
                            "closeButton": false,
                            "debug": false,
                            "newestOnTop": false,
                            "progressBar": false,
                            "positionClass": "toast-bottom-right",
                            "preventDuplicates": false,
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        }

                        $("#listTable").load(`${location.href} #listTable`);
                    }
                    else {
                        toastr["error"](failedOperationMessage)
                        toastr.options = {
                            "closeButton": false,
                            "debug": false,
                            "newestOnTop": false,
                            "progressBar": false,
                            "positionClass": "toast-bottom-right",
                            "preventDuplicates": false,
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        }
                    }

                },
            });
        }
    })
}


const deleteRoomTitleMessage = "از حذف این اتاق مطمئن هستید؟"
const deleteRoomTextMessage = "در صورت حذف این اتاق؛ این اتاق از لیست اتاق های موجود حذف می شود !";
function ShowAlertRoom(id, action) {
    var title, text;
    if (action === "Delete") {
        title = deleteRoomTitleMessage;
        text = deleteRoomTextMessage;
    }
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'لغو'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/RoomManagement/${action}?id=${id}`,
                type: "post"
                , success: function (response) {
                    if (response.status === "success") {
                        toastr["success"](successOperationMessage)
                        toastr.options = {
                            "closeButton": false,
                            "debug": false,
                            "newestOnTop": false,
                            "progressBar": false,
                            "positionClass": "toast-bottom-right",
                            "preventDuplicates": false,
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        }

                        $("#listTable").load(`${location.href} #listTable`);
                    }
                    else {
                        toastr["error"](failedOperationMessage)
                        toastr.options = {
                            "closeButton": false,
                            "debug": false,
                            "newestOnTop": false,
                            "progressBar": false,
                            "positionClass": "toast-bottom-right",
                            "preventDuplicates": false,
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        }
                    }

                },
            });
        }
    })
}

function OperationResult(response) {
    debugger;
    if (response.status === "success") {
        window.location.href = "https://localhost:7180" + response.redirectAction;
        $("#listTable").load(`${location.href} #listTable`);
    } else if (response.status === "error") {
        toastr["error"](response.message)
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }
}