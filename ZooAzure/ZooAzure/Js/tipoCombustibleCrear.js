$(document).ready(function () {





    $('#btnCancelar').click(function () {
        debugger;

        window.location.href = './tipoCombustible.html';
        

    });


    $('#btnCrear').click(function () {


        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.ajax({
            url: `/api/tipoCombustible`,
            type: "POST",
            dataType: 'json',
            data: {
                denominacion: $('#denominacion').val()
            },
            success: function (respuesta) {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // ME REDIRECCIONO A LA LISTA DE MARCAS
                window.location.href = './tipoCombustible.html';
            },

            error: function (respuesta) {
                console.log(respuesta);
            }
        });

    });

});