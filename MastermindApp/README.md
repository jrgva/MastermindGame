MastermindGame

- Lo de darme cuenta del ultimo ejemplo, se aceptan mas combinaciones separadas por comas
- Ya que tenia que hacer tests unitarios, hice TDD
- Empece haciendolo para el caso simple y luego amplie para el caso mas complejo de 2 o mas entradas
- no importa si los colores estan bien escritos o no
- Para no complicar la logica de entrada del guess, decidi ponerle un regex que tenga que cumplir y obligar al usuario a seguir ese patron
- El patron de los guesses no pude hacerlo para que pillara la frase entera, asi que he tenido que formatear yo la propia frase
- Aunque no lo dice explicitamente, creo que es necesaria una interfaz de usuario, en este caso por consola y por eso la he hecho.
- Pense en un vs la maquina