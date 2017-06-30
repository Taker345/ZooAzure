$(document).ready(function () {



    function cargarDetalle() {

        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/tipoCombustible/${id}`, function (respuesta, estado) {            
                // COMPRUEBO EL ESTADO DE LA LLAMADA
                if (estado === 'success') {
                    // SI LLEGO HASTA AQUÍ QUIERE DECIR
                    // QUE EN 'RESPUESTA' TENGO LA INFO
                    $('#denominacion').val(respuesta.dataCombu[0].denominacion);

            }
        });
    }

    $('#btnCancelar').click(function () {
        debugger;

        window.location.href = './tipoCombustible.html';
        

    });


    $('#btnActualizar').click(function () {


        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.ajax({
            url: `/api/tipoCombustible/${id}`,
            type: "PUT",
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

    cargarDetalle();

});