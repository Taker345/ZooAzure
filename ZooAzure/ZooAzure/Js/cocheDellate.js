$(document).ready(function () {



    function cargarDetalle() {
        
        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/coches/${id}`, function (respuesta, estado) {
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // QUE EN 'RESPUESTA' TENGO LA INFO
                $('#matricula').html(respuesta.data[0].matricula);
                $('#marca').html(respuesta.data[0].marca.denominacion);
                $('#combustible').html(respuesta.data[0].tipoCombustible.denominacion);
                $('#cilindrada').html(respuesta.data[0].cilindrada);
                $('#plazas').html(respuesta.data[0].nPlazas);
                $('#color').html(respuesta.data[0].color);
                $('#fecha').html(mensajes.dateToString(respuesta.data[0].fechaMatriculacion));
                
            }
        });
    }
        

    cargarDetalle();


});