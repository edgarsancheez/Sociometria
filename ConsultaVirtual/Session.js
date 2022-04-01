
           //parametros
           //var timeLimit = 1.2 //tiempo en minutos
           var timeLimit = 1.2 //tiempo en minutos
           var PaginaCierre = "Acceso.aspx" //pagina de cierre de session
           var ConteoLimite = 59000 //limite en que aparecere el mensaje

           var conteo = new Date(timeLimit * 60000); //tiempo en segundos =60,000=1seg=1000
          


           function inicializar() 
           {
              // document.getElementById('LTIEMPO').style.display = 'none';  //hacer invisible un label
              // document.all("LTIEMPO").innerText = "La sesión actual expira en " + timeLimit + ":00 minuto(s)." + conteo.getTime()  //=conteo.getMinutes() + ":" + conteo.getSeconds();
               cuenta(); //invoca a la funcion
           }

           function cuenta() 
           {
               intervaloRegresivo = setInterval("regresiva()", 1000); //invoca a la funcion regresiva
           }

           function regresiva() 
           {
                if (conteo.getTime() > 0) 
                {
                    conteo.setTime(conteo.getTime() - 1000);
                    if (conteo.getTime() == ConteoLimite) 
                    {
                       // document.getElementById('LTIEMPO').style.display = 'block';  //hacer visible un label
                        OpenConfirm();
                    }
                } 
                else 
                {
                    clearInterval(intervaloRegresivo);
                    window.location.href = PaginaCierre; //pagina  de cierre
                }
              //  document.all("LTIEMPO").innerText = "La sesión actual expira en " + conteo.getMinutes() + ":" + conteo.getSeconds() + " minuto(s)." + conteo.getTime(); //incrementa un segundo
            }
            onload = inicializar; //al cargar la funcion la inicializa





            //functions radwindows
            function OpenWindow() 
            {
                var wnd = window.radopen("http://www.bing.com", 'Window1');
                wnd.setSize(400, 400);
                return false;
            }

            function OpenConfirm() {
                //radconfirm("<strong><h3 style='color: #ff0000;'>La sesión actual esta por  terminar, desea continuar con la información actual?<strong></h3>", confirmCallBackFn, 330, 100, null, 'Cierre de aplicación');
                radconfirm("<h3 style='color: black; font-family: arial; font-size: 14px;'>La sesión actual está por terminar, desea continuar con la información actual?</h3>", confirmCallBackFn, 400, 100, null, 'Cierre de aplicación');
                return false;
            }

            function confirmCallBackFn(arg) {
                // radalert("<strong>radconfirm</strong> returned the following result: <h3 style='color: #ff0000;'>" + arg + "</h3>", null, null, "Result");
                if (arg == true) {
                     //location.reload(true); //refresca la pagina actual
                     var url = window.location
                     window.location.href = url;
                     }
                else {
                     window.location.href = PaginaCierre; //pagina  de cierre
                     }
            }
