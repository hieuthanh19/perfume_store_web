var cart = {
    init: () => {
        cart.regEvents()
    },
    regEvents: () => {
        $('#btnUpdate').off('click').on('click', () => {
            var listProducts = $('.txtQuantity');
            var cartList = [];
            $.each(listProducts, function(i, item){
                cartList.push({
                    Quantity: $(this).val(),
                    Product: {
                        product_id: $(item).data('id')
                    }
                })
            })

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/Cart"
                    }
                    else if (res.status == false) {
                        window.location.href = "/Cart"
                        alert("Input quantity is greater than available quantity")
                    }
                    
                }
            })
        })
    }
}

cart.init(); 