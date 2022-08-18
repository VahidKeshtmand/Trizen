// const successOperationMessage = "عمبیات با موفقیت انجام شد !";
// const failedOperationMessage = "عمبیات ناموفق بود !";

// function ShowAlertHotel(id, action) {
//     Swal.fire({
//         title: title,
//         text: text,
//         icon: 'warning',
//         showCancelButton: true,
//         confirmButtonColor: '#3085d6',
//         cancelButtonColor: '#d33',
//         confirmButtonText: 'بله',
//         cancelButtonText: 'لغو'
//     }).then((result) => {
//         if (result.isConfirmed) {
//             $.ajax({
//                 url: `/HotelManagement/${action}?id=${id}`,
//                 type: "post"
//                 , success: function (response) {
//                     if (response.status === "success") {
//                         toastr["success"](successOperationMessage)
//                         toastr.options = {
//                             "closeButton": false,
//                             "debug": false,
//                             "newestOnTop": false,
//                             "progressBar": false,
//                             "positionClass": "toast-bottom-right",
//                             "preventDuplicates": false,
//                             "onclick": null,
//                             "showDuration": "300",
//                             "hideDuration": "1000",
//                             "timeOut": "5000",
//                             "extendedTimeOut": "1000",
//                             "showEasing": "swing",
//                             "hideEasing": "linear",
//                             "showMethod": "fadeIn",
//                             "hideMethod": "fadeOut"
//                         }

//                         $("#listTable").load(`${location.href} #listTable`);
//                     }
//                     else {
//                         toastr["error"](failedOperationMessage)
//                         toastr.options = {
//                             "closeButton": false,
//                             "debug": false,
//                             "newestOnTop": false,
//                             "progressBar": false,
//                             "positionClass": "toast-bottom-right",
//                             "preventDuplicates": false,
//                             "onclick": null,
//                             "showDuration": "300",
//                             "hideDuration": "1000",
//                             "timeOut": "5000",
//                             "extendedTimeOut": "1000",
//                             "showEasing": "swing",
//                             "hideEasing": "linear",
//                             "showMethod": "fadeIn",
//                             "hideMethod": "fadeOut"
//                         }
//                     }

//                 },
//             });
//         }
//     })
// }




function OperationResult(response) {
    if (response.status === "success") {
        toastr["success"](response.message)
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