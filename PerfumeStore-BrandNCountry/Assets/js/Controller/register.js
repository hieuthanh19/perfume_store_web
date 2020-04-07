var register = {
    registerControl: function () {
        $('#btnRegister').click(function () {
            register.createAccount();
        })
    },
    createAccount: function () {
        $.ajax({
            url: '/Register/Register',
            type: 'POST',
            data: {
                name: $('#name').val(),
                email: $('#email').val(),
                password: $('#password').val(),
                confirmPassword: $('#pass').val(),
            },
            success: function (res) {
                $('#alertNotification').empty();
                if (res.status) {
                    $('#alertNotification').html('<span class="text-success">Register success</span>');
                }
                else {
                    $('#alertNotification').html('<span class="text-danger">' + res.msg + '</span>');
                }
            }
        })
    }
};
$(document).ready(function () {
    register.registerControl();
});