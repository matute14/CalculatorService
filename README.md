# CalculatorService
Coding challenge calculator service
Solucion calculadora 
El codigo de la aplicacion esta hecho en c# usando .net Core 3.1 
Composicion
tiene una aplicacion de consola en la cual esta integrada el cliente,
El cliente tiene un menu donde eliges la opcion del menu deseada 
Y pregunta por si quieres persistir las operaciones para opcionalmente ver el historial de operaciones 

Una aplicacion de servidor que es donde tiene los controladores que van a comunicarse con el cliente
mediante JSON las respuestas y las peticiones se hacen mediante objetos serializados con  JSON ya que es una API REST

Otra solucion que sirve de libreria para tener los modelos de respuesta y peticion 

Para el despligue de la aplicacion sera necesario arrancar las soluciones de CalculatorClient y CalculatorServer
