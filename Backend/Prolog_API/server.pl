% Bibliotecas
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:-use_module(library(persistency)).
:-use_module(library(semweb/rdf_db)).


%:-ensure_loaded('base').

% Relação entre pedidos HTTP e predicados que os processam
:- http_handler('/lapr5', responde_ola, []).
:- http_handler('/register_user', register_user, []).
:- http_handler('/send_file_post', send_file_post, []).
:- http_handler('/receive_path_post', receive_path_post, []).
:-http_handler('/receive_warehouse_post',receive_warehouse_post,[]).
:-http_handler('/receive_order_post',receive_order_post,[]).

:- dynamic a/1.

% :-include('/lei21-22-s5-3dj-56/Backend/GestLogistica_API/GestLogistica/src/core/infra/orders.pl').
% :-include('warehousesBD.pl'). :-include('truckBD.pl').

:-dynamic orders/4.


% Criar servidor HTTP no porto 'Port'
server(Port) :-
        http_server(http_dispatch, [port(Port)]).

% Tratamento de 'http://localhost:5000/lapr5'
responde_ola(_Request) :-
        format('Content-type: text/plain~n~n'),
        format('OlÁ LAPR5!~n').


send_file_post(Request) :-
	http_parameters(Request,[ file(X,[])]),
        format('Content-type: text/plain~n~n'),
        consult([X]),
        format('Received: ~w~n',[X]).


% METODO POST enviando um ficheiro de texto
% http_client:http_post('http://localhost:5000/send_file_post', form_data([file=file('./teste.txt')]), Reply, []).


%POST Path = 'http://localhost:5003/receive_path_post'
receive_path_post(Request):-
        http_parameters(Request, [ file(X,[])]),
        format('Content-type: text/plain~n~n'),
        absolute_file_name('path.pl',D),
        open(D,write,OS),
        write(OS,X),
        nl(OS),
        close(OS),
        format('Received: ~w~n',[X]).

%POST Path = 'http://localhost:5003/receive_warehouse_post'
receive_warehouse_post(Request):-
        http_parameters(Request, [file(X,[])]),
        format('Content-type: text/plain~n~n'),
        absolute_file_name('warehouse.pl',D),
        open(D,write,OS),
        write(OS,X),
        nl(OS),
        close(OS),
        format('Received: ~w~n',[X]).

%POST Path = 'http://localhost:5003/receive_order_post'
receive_order_post(Request):-
        http_parameters(Request, [file(X,[])]),
        format('Content-type: text/plain~n~n'),
        absolute_file_name('order.pl',D),
        open(D,write,OS),
        write(OS,X),
        nl(OS),
        close(OS),
        format('Received: ~w~n',[X]).

% WRITE AND READ FILES FOR BASE KNOWLEDGE:

file_write():-
    %absolute_file_name('base',D),
    absolute_file_name('base.pl',D),
    open(D,write,OS),
    write(OS,'ficheijjhkjhroaa.'),
    nl(OS),
    close(OS).

append_file():-
    absolute_file_name('base.pl',D),
    open(D,append,OS),
    write(OS,'aaaaaa'),
    nl(OS),
    close(OS).

readfacts():-
    %absolute_file_name('../lei21-22-s5-3dj-56/Backend/Prolog_API',D,[file_type(prolog),relative_to('base.pl')]),
    %absolute_file_name('lei21-22-s5-3dj-56/Backend/Prolog_API/base.pl',D),
    %writef(D),
    absolute_file_name('base.pl',D),
    open(D,read,Str),
    read_houses(Str,Houses),
    close(Str),
    write(Houses),  nl.

read_houses(Stream,[]):-
    at_end_of_stream(Stream).

read_houses(Stream,[X|L]):-
    \+  at_end_of_stream(Stream),
    read(Stream,X),
    read_houses(Stream,L).




