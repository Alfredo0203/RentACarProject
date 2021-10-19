function GuardarEnCarrito(id) {
    $.ajax({
        url: '/Carrito/SeleccionarProducto?id=' + id,
        type: 'POST',
        async: true,
        data: '',
        success: function (resultado) {
            if (resultado == true) {
                Swal.fire({
                    title: '¡Producto Agregado exitosamente!',
                    icon: 'success',
                    confirmButtonText: 'OK',
                    confirmButtonPosition: 'center',
                    confirmButtonColor: '#0067b8',
                    timer: 9000,
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.reload(true)
                    }
                })

            } else if (resultado == false) {
                Swal.fire({
                    title: '¡No se puede tener más de un producto en Carrito!',
                    text: "Es posible que ya tengas producto en carrito",
                    icon: 'error',
                    confirmButtonText: 'OK',
                    confirmButtonPosition: 'center',
                    confirmButtonColor: '#0067b8',
                    timer: 9000,
                }).then((result) => {
                    if (result.isConfirmed) {
                        
                    }

                })
                //FINALIZA EL DIALOGO E NOTIFICACIÓN
            }
        }

    });

}