$(document).ready(function () {





    $('#btnCancelar').click(function () {
        debugger;

        window.location.href = './coche.html';
        

    });


    $('#btnCrear').click(function () {


        var id = window.location.search.substring(1).split('=')[1];
        

        // PREPARAR LA LLAMDA AJAX 
        $.ajax({
            url: `/api/coches/`,
            type: "POST",
            dataType: 'json',
            data: {
                matricula: $('#matricula').val(),
                nPlazas: $('#plazas').val(),
                cilindrada: $('#cilindrada').val(),
                color: $('#color').val(),
                fechaMatriculacion: $('#fecha').val(),
                marca: {
                    id: $('#marca').val()
                },
                tipoCombustible: {
                    id: $('#combustible').val()
                }

                    
            },
            success: function (respuesta) {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // ME REDIRECCIONO A LA LISTA DE MARCAS
                //window.location.href = './marcas.html';
                debugger;
            },

            error: function (respuesta) {
                console.log(respuesta);
            }
        });

    });

});