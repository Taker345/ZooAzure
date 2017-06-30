$(document).ready(function () {



    function cargarDetalle() {
        
        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/marcas/${id}`, function (respuesta, estado) {
            debugger;
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // QUE EN 'RESPUESTA' TENGO LA INFO
                var contenido = '';
                contenido += respuesta.dataMarca[0].denominacion;

                $('#resultados').html(contenido);

            }
        });
    }
    cargarDetalle();

});