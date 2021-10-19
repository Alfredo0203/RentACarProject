 function EliminarDelCarritoCarrito(id) {
        $.ajax({
            url: '/Carrito/EliminarElementoDeLaLista?id=' + id,
            type: 'POST',
            async: true,
            data: '',
            success: function (resultado) {
                if (resultado == true) {
                    Swal.fire({
                        title: '¡Producto de tu colección eliminado exitosamente!',
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
                    //FINALIZA EL DIALOGO E NOTIFICACIÓN
                } else {
                    //INICIA ELDIALOGO DE NOTIFICACIÓN
                    Swal.fire({
                        title: '¡No se pudo eliminar!',
                        text: "Actualice la página y vuelve a intentarlo",
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