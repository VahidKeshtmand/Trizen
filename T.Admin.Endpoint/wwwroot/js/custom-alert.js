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

const deleteDiscountTitleMessage = "از حذف تخفیف مطمئن هستید؟"
const deleteDiscountTextMessage = "در صورت حذف تخفیف؛ تخفیف موجود از روی قیمت برداشته می شود !";
function ShowAlertDiscount(id, action) {
    var title, text;
    if (action === "Delete") {
        title = deleteDiscountTitleMessage;
        text = deleteDiscountTextMessage;
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
                url: `/DiscountManagement/${action}?id=${id}`,
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

const deleteCommentTitleMessage = "از حذف این نظر مطمئن هستید؟"
const deleteCommentTextMessage = "در صورت حذف این نظر؛ این نظر از لیست نظر های موجود حذف می شود !";
const confirmedCommentTitleMessage = "از ثبت این نظر مطمئن هستید؟"
const confirmedCommentTextMessage = "در صورت ثبت این نظر؛ این نظر به نظرات موجود در سایت اضافه می شود !";
function ShowAlertRoom(id, action) {
    var title, text;
    if (action === "Delete") {
        title = deleteRoomTitleMessage;
        text = deleteRoomTextMessage;
    }
    if (action === "Confirmed") {
        title = confirmedCommentTitleMessage;
        text = confirmedCommentTextMessage;
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
                url: `/CommentManagement/${action}?id=${id}`,
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

const deleteAirlineCompanyTitleMessage = "از حذف شرکت هواپیمایی مطمئن هستید؟"
const deleteAirlineCompanyTextMessage = "در صورت حذف شرکت هواپیمایی؛ این شرکت هواپیمایی از لیست شرکت هواپیمایی های موجود حذف می شود !";
const deleteFlightTitleMessage = "از حذف این پرواز مطمئن هستید؟"
const deleteFlightTextMessage = "در صورت حذف این پرواز؛ این پرواز از لیست پرواز های موجود حذف می شود !";
function ShowAlertFlight(id, action) {
    var title, text;
    if (action === "DeleteAirlineCompany") {
        title = deleteAirlineCompanyTitleMessage;
        text = deleteAirlineCompanyTextMessage;
    }
    if (action === "DeleteFlight") {
        title = deleteFlightTitleMessage;
        text = deleteFlightTextMessage;
    }
    Swal.fire({
        title: title,
        text: text,
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'لغو'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/FlightManagement/${action}?id=${id}`,
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