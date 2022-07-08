function RegisterSubmitted(response) {
    if (response.status === "Success") {
        Swal.fire({
            icon: 'success',
            title: 'موفق',
            text: 'شما با موفقیت ثبت نام کردید.',
            confirmButtonText: 'تأیید'
        }).then((result) => {
            if (result.isConfirmed) {
                $("#loginPopupForm").modal("hide");
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

function LoginSubmitted(response) {
    if (response.status === "Success") {
        Swal.fire({
            icon: 'success',
            title: 'موفق',
            text: 'ورود موفقیت آمیز.',
            confirmButtonText: 'تأیید'
        }).then((result) => {
            if (result.isConfirmed) {
                $("#loginPopupForm").modal("hide");
                location.reload();
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'اخطار',
            text: 'ورود ناموفق',
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
    } else if (response.status === "Warning") {
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

function SendToken() {
    $.ajax({
        url: "/Account/SendToken",
        type: "post"
        , success: function (response) {
            if(response.status === "Warning"){
                Swal.fire({
                    icon: 'warning',
                    title: 'هشدار',
                    text: response.message,
                    confirmButtonText: 'تأیید'
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            }
            
        }
    });
    $('#btn-send-sms').css({
        "pointer-events": "none",
        "opacity": "0.5",
    });
    var timeLeft = 60;
    var timerId = setInterval(countdown, 1000);

    function countdown() {
        if (timeLeft == -1) {
            $('#btn-send-sms').css({
                "pointer-events": "initial",
                "opacity": "1",
            });
            var btn = document.getElementById('btn-send-sms');
            btn.innerHTML = "ارسال مجدد پیامک";
            clearTimeout(timerId);
            doSomething();
        } else {
            timeLeft--;
        }
    }
}
