# PiaCasinoAppi
Caso de estudio de casino
Un casino quiere implementar un sistema que le permita crear rifas para que sus clientes puedan participar en ellas.
Requerimientos:
El sistema debe de permitir que un usuario administrador permita crear una rifa, solamente ese usuario podrá tener acceso a las API de creación, modificación y eliminación de rifas.

El sistema deberá permitir la creación de participantes, y se tendrá un límite de 54 participantes por rifa, ya que se hará con los # de la lotería mexicana.

Los participantes podrán registrarse en una rifa, por lo que deberá de existir un registro en la base de datos relacionando el participante, la rifa y el # de lotería.

No se podrá seleccionar un # de lotería que ya se encuentre relacionado a un participante. El controlador al obtener los # de lotería por rifa solo mostrará los # disponibles y no todo el listado.

La búsqueda de los # de lotería deberá de ser por Id de la rifa y por nombre de la rifa.

El sistema deberá permitir al administrador, eliminar registros de participante para una rifa, el participante no podrá eliminarlos el mismo.

El participante solo podrá tener la funcionalidad de consultar rifas, consultar números de esa rifa (al cargar la rifa, deberá de cargar la entidad relacionada de los # disponibles, sin embargo, deberá de existir el servicio para obtener los # de lotería por su cuenta).

El sistema deberá de contar con una funcionalidad donde el administrador mande una petición a un EndPoint enviando el Id de la rifa, y la aplicación responda con 1 # de la lotería de esa rifa (que se encuentre participando o sea que tenga relación) para seleccionar un ganador random entre los participantes.

Al obtener el ganador el sistema deberá de enviar la tarjeta ganadora, junto con el nombre relacionado a ella en la rifa y los datos del participante.
El sistema deberá contar con una funcionalidad donde podamos registrar Premios para cada una de las rifas, al momento de seleccionar un ganador random con la funcionalidad descrita arriba también deberemos mostrar que premio le toca, es decir.

Si una rifa tiene 5 premios, podemos realizar 5 ejecuciones al servicio de obtener ganador, los # de tarjeta ganadores no se pueden repetir por lo que si ya ganaron se sacarán del listado y no se contarán para los premios restantes.

Los premios deberán tener un orden es decir 1er lugar, 2do lugar, 3ro, etc.
La primera ejecución de obtener el ganador, deberá obtener el premio de menor rango, e irá aumentando es decir si una rifa tiene 6 premios, la 6ta tirada al servicio de jugador random ganador se llevará el 1er lugar.

El sistema deberá permitir hacer un recorrido de todas las tarjetas de lotería de forma random sin repetirlas, esto deberá de usarse por sesión como recomendación pueden usar los tipos de servicio o el cache. Aunque sería mejor los tipos de servicio que se usaron.

Equipo de desarrolladores:
JOSUE CARRIZALES NUÑEZ
JAIME ALEJANDRO GONZALEZ PACHECO
