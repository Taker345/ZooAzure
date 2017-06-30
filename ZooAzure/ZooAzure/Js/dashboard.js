$(document).ready(function () {

    mensajes.cargarDatosUsuario(function (datosUsuario, error) {

        if (datosUsuario === null) {
            window.location.href = '/login.html'
        }


    });



   
});


//mensajes.checkLogin('121@test.com', '1212', function (resultado, error) {
//    debugger;
//    console.log('estoy en el callback');
//    if (!resultado || (resultado === undefined)) {
//        mensajes.showSwal('error', 'Login Error', 'No se pudo hacer login');
//        return;
//    }
//    window.location.href = '/login.html';

//});