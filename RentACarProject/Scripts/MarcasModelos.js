var btnAgregarMarca = document.getElementById("ModalMarca");
var btnEditMarca = document.getElementById("EditMarca");

var btnAgregarModelo = document.getElementById("ModalModelo");
var btnEditModelo = document.getElementById("EditModelo");


$(function () {
    var MarcasModal = $('#MarcasModal');
    $(btnAgregarMarca).click(function (event) {
        var url = $(this).data('url');
        async: false,
            $.get(url).done(function (data) {
                MarcasModal.html(data);
                MarcasModal.find('.modal').modal('show');
            })
    })

})


$(function () {
    var MarcasModal = $('#MarcasModal');
    $('button[data-toggle="ajax-modal-EditMarca"]').click(function (event) {
        var url = $(this).data('url');
        async: false,
            $.get(url).done(function (data) {
                MarcasModal.html(data);
                MarcasModal.find('.modal').modal('show');
            })
    })

})


function EliminarMarca(IdMarca) {
    Swal.fire({
        title: '¿Estás seguro que quieres eliminar la marca seleccionada?',
        text: 'Se eliminarán todos los modelos de automóvil de dicha marca',
        icon: 'warning',
        showConfirmButton: true,
        confirmButtonText: 'Aceptar',
        showCancelButton: true,
        cancelButtonText: 'Cancelar',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        allowOutsideClick: false,
        allowEscapekey: false,
        stopKeydownPropagation: false,
        backdrop: true,
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "/MarcasModelos/EliminarMarca?IdMarca=" + IdMarca;
        }
    })
}


$(function () {
    var ModelosModal = $('#ModeloModal');
    $(btnAgregarModelo).click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            ModelosModal.html(data);
            ModelosModal.find('.modal').modal('show');
        })
    })
})

$(function () {
    var ModelosModal = $('#ModeloModal');
    $('button[data-toggle="ajax-modal-EditModelo"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            ModelosModal.html(data);
            ModelosModal.find('.modal').modal('show');
        })
    })
})

function EliminarModelo(IdModelo) {
    Swal.fire({
        title: '¿Estás seguro que deseas eliminar el modelo seleccionado?',
        text: 'Una vez eliminado no podras recuperarlo.',
        icon: 'warning',
        showConfirmButton: true,
        confirmButtonText: 'Aceptar',
        showCancelButton: true,
        cancelButtonText: 'Cancelar',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        allowOutsideClick: false,
        allowEscapekey: false,
        stopKeydownPropagation: false,
        backdrop: true,
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "/MarcasModelos/EliminarModelo?IdModelo=" + IdModelo;
        }
    })
}

