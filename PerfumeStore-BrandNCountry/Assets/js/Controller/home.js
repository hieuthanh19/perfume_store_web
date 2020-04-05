var account = {
    registerControl: function () {
        $('#btnLogin').click(function () {
            account.login();
        })
    },
    addFaveList: function () {
        $.ajax({
            url: '/Home/AddToFavoriteList',
            type: 'GET',
            data: {
                id: data
            },
            success: function (res) {
                if (res.status) {
                    window.location.href = '/FavList/Index';
                }
                else {
                    $.notify(res.msg,'error');
                }
            }
        })
    }
};
$(document).ready(function () {
    account.registerControl();
});