# Jornada Arquitectura .NET - De Procedular A Objetos

## Painters Company

[![N|Net-Baires](http://www.germankuber.com.ar/wp-content/uploads/Blanco-small.png)](https://www.net-baires.com.ar/)

# Requerimientos

### 01 - Cheapest Painter

  - Dadas las dimensiones en metros de una superficie, se debe obtener el pintor mas barato para pintarla.
  - Solo seran considerados los pintos que se encuentren disponible en ese momento para realizar el trabajo.

### 02 - Fastest Painter

  - Dadas las dimensiones en metros de una superficie, se debe obtener el pintor mas rápido para pintarla.
  - Solo seran considerados los pintos que se encuentren disponible en ese momento para realizar el trabajo.
  - Los pintores que no se encuentran disponible para realizar el trabajo en ese momento, deben poder ser reconocidos y excluidos inicialmente de toda busqueda.
  
### 03 - Work Together

  - Dadas las dimensiones en metros de una superficie, se debe obtener el tiempo y el precio que el conjunto de pintores disponibles consumirá para realizar el trabajo.
  - Los pintores que se encuentren de vacaciones, seran considerados para este nuevo calculo, aunque estos contarán con una tarifa especial, indicada por cada pintor.
  - Todos los pintores que se encuentren en vacaciones deben  indicar cual es el costo de trabajar dentro de ellas.
  - Solo los pintores que no se encuentren disponible seran excluidos de este proceso.