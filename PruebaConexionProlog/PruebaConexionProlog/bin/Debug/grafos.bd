
 
 :- dynamic conexionMatriz/3, grupo/1, insertaGrupo/1.
 
%lugar(pueblo).
%
conectado(florencia,cq).
conectado(florencia,santa_clara).
conectado(cq,la_abundancia).
conectado(la_abundancia, javillos).
conectado(santa_clara,javillos).
conectado(santa_clara,florencia).
conectado(santa_clara,la_abundancia).
conectado(cq,santa_clara).

conectado(inicio,2).

 conectado(1,7).

 conectado(2,3).

 conectado(2,8).

 conectado(3,9).

 conectado(3,4).

 conectado(4,10).

 conectado(5,6).

 conectado(5,11).

 conectado(7,13).

 conectado(8,9).

 conectado(10,16).

 conectado(11,17).

 conectado(12,18).

 conectado(13,14).

 conectado(15,14).

 conectado(14,20).

 conectado(21,15).

 conectado(16,22).

 conectado(17,23).

 conectado(17,18).

 conectado(18,24).

 conectado(19,25).

 conectado(20,26).

 conectado(22,21).

 conectado(23,29).

 conectado(24,30).

 conectado(25,31).

 conectado(26,27).

 conectado(27,28).

 conectado(28,34).

 conectado(28,29).

 conectado(30,36).

 conectado(31,32).

 conectado(33,32).

 conectado(34,33).

 conectado(34,35).

 conectado(35,36).

 conectado(32,fin).

cargar(A):-exists_file(A),consult(A).
%ruta(X,Y)
%
conectado_con(X,Y):- conectado(X,Y).
conectado_con(X,Y):- conectado(Y,X).
%




insertaGrupo(Y) :- assert(grupo(Y)).

conexionMatriz_con(X,Y,Z):-conexionMatriz(X,Y,Z).

existeGrupo(X):- grupo(X).

encontraVecinos(X,Y,Z):- conexionMatriz(X,Y,Z).







ruta1(Lugar,Lugar,[Lugar]).
ruta1(Inicio,Fin,[Inicio|Camino]):-
    conectado(Inicio,AlgunLugar),
    ruta1(AlgunLugar,Fin,Camino).

ruta2(Lugar,Lugar,_,[Lugar]).

ruta2(Inicio,Fin,Visitados,[Inicio|Camino]):-
    conectado_con(Inicio,AlgunLugar), %conectado para el grafo
    not(member(AlgunLugar,Visitados)),
    ruta2(AlgunLugar,Fin,[Inicio|Visitados],Camino).
	
	
ruta(Inicio,Fin,Camino):-
    Inicio\=Fin,
    ruta2(Inicio,Fin,[],Camino), write(Camino).
