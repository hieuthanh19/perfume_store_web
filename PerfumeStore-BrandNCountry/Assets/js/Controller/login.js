var account = {
    registerControl: function () {
        $('#btnLogin').click(function () {
            account.login();
        })
    },
    login: function () {
        var data = {
            username: $('#usernamelogin').val(),
            password: $('#passwordlogin').val()
        }
        $.ajax({
            url: '/SignIn/SignIn',
            type: 'POST',
            data: {
                model : data
            },
            success: function (res) {
                $('#alertLogin').empty();
                if (res.status) {
                    $('#alertLogin').html('<span class="text-success">Sign in success</span>');
                    window.location.href = '/';
                }
                else {
                    $('#alertLogin').html('<span class="text-danger">' + res.msg + '</span>');
                }
            }
        })
    }
};
$(document).ready(function () {
    account.registerControl();
});