function RegisterSubmitted(response) {
    if (response.status === "Success") {
        Swal.fire({
            icon: 'success',
            title: 'موفق',
            text: 'شما با موفقیت ثبت نام کردید.',
            confirmButtonText: 'تأیید'
        }).then((result) => {
            if (result.isConfirmed) {
                $("#signupPopupForm").modal("hide");
                window.location.href = '/Account/VerifyPhoneNumber';
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'اخطار',
            text: 'ثبت نام ناموفق. لطفاً دوباره تلاش کنید.',
            confirmButtonText: 'تأیید'
        });
    }
}

function VerifyPhoneNumberSubmitted(response) {
    if (response.status === "Success") {
        Swal.fire({
            icon: 'success',
            title: 'موفق',
            text: 'شماره موبایل شما با موفقیت ثبت شد.',
            confirmButtonText: 'تأیید'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = '/Account/Profile';
            }
        });
    } else if (response.status === "warning") {
        Swal.fire({
            icon: 'warning',
            title: 'توجه',
            text: response.message,
            confirmButtonText: 'تأیید'
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'اخطار',
            text: response.message,
            confirmButtonText: 'تأیید'
        });
    }
}


