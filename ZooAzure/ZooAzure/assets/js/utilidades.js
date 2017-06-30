type = ['', 'info', 'success', 'warning', 'danger'];


mensajes = {
    showSwal: function (type, title, text) {
        if (type == 'aviso') {
            swal({
                title: title,
                text: text,
                type: "warning",
                
            });
            return;
        } if (type == 'error') {
            swal({
                title: title,
                text: text,
                type: "danger",
           
                
            });
            return;
        }
        if (type == 'exito') {
            swal({
                title: title,
                text: text,
                type: "success",

            });
            return;
        }









    },  
    checkLogin: function (email, password, cb) {
        debugger;
        $.ajax({
            url: '/api/login',
            type: "POST",
            dataType: 'json',
            data: {
                email: email,
                password: password,
            },

            //todo correcto
            success: function (respuesta) {
                if (respuesta !== null && respuesta.error !== '') {
                    //mensaje.showSwal('error', 'Atencion', respuesta.error)
                    return cb(null, respuesta.error);
                }

                if (respuesta !== null && respuesta.error === '' && respuesta.totalElementos === 0) {
                    //mensajes.showSwal('error', 'Atención', 'Usuario inexistente o no encontrado');
                    return cb(null, 'Usuario inexistente o no encontrado');
                }
                if (respuesta !== null && respuesta.error === '') {
                    //mensajes.showSwal('aviso', 'éxito', 'Usuario encontrado');
                    //hacer redireccion a dashboard
                    //window.location.href = "/dashboard.html";
                    return cb(respuesta.dataUsuario[0], null);                    
                }
            },
            //aqui hay error
            error: function (respuestar) {
                mensajes.showSwal('error', 'Error en la llamada', '' + respuesta.status);
                console.log(respuesta);
            }
        });
    },
    cargarDatosUsuario: function (cb){
        var datosUsuario = null;
        var obj = localStorage.getItem('usuarioLogueado')
        if (obj !== null && obj !== undefined) {
        datosUsuario = JSON.parse(obj);
            
        }
    return cb(datosUsuario, null);
    },
    dateToString: function (stringDate) {
        var fechaFomateada = '';
        var fecha = new Date(stringDate);
        var dia = fecha.getDate();
        var mes = (fecha.getMonth() + 1);
        fechaFomateada = (dia < 10 ? '0' + dia : dia) + '/' + (mes < 10 ? '0' + mes : mes) + '/' + fecha.getFullYear();
        return fechaFomateada;
    }
}