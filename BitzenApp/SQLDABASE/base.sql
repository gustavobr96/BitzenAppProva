toc.dat                                                                                             0000600 0004000 0002000 00000037377 13716745116 0014473 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP                	            x         	   bd_bitzen    12.4    12.4 6    F           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         G           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         H           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         I           1262    16396 	   bd_bitzen    DATABASE     �   CREATE DATABASE bd_bitzen WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Portuguese_Brazil.1252' LC_CTYPE = 'Portuguese_Brazil.1252';
    DROP DATABASE bd_bitzen;
                postgres    false         �            1259    24601    ger_abastecimento    TABLE     r  CREATE TABLE public.ger_abastecimento (
    n_km_abastecimento double precision,
    n_litro_abastecimento double precision,
    v_vlr_pago double precision,
    d_abastecimento date,
    n_cod_posto integer,
    n_cod_usuario integer,
    n_cod_combustivel integer,
    n_cod_veiculo integer,
    n_cod_tipo_veiculo integer,
    n_cod_abastecimento integer NOT NULL
);
 %   DROP TABLE public.ger_abastecimento;
       public         heap    postgres    false         �            1259    32797 )   ger_abastecimento_n_cod_abastecimento_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_abastecimento_n_cod_abastecimento_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 @   DROP SEQUENCE public.ger_abastecimento_n_cod_abastecimento_seq;
       public          postgres    false    215         J           0    0 )   ger_abastecimento_n_cod_abastecimento_seq    SEQUENCE OWNED BY     w   ALTER SEQUENCE public.ger_abastecimento_n_cod_abastecimento_seq OWNED BY public.ger_abastecimento.n_cod_abastecimento;
          public          postgres    false    218         �            1259    16409 	   ger_marca    TABLE     k   CREATE TABLE public.ger_marca (
    n_cod_marca integer NOT NULL,
    c_descricao character varying(60)
);
    DROP TABLE public.ger_marca;
       public         heap    postgres    false         �            1259    16430    ger_marca_n_cod_marca_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_marca_n_cod_marca_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public.ger_marca_n_cod_marca_seq;
       public          postgres    false    204         K           0    0    ger_marca_n_cod_marca_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.ger_marca_n_cod_marca_seq OWNED BY public.ger_marca.n_cod_marca;
          public          postgres    false    209         �            1259    16460    ger_marca_x_ger_modelo    TABLE     b   CREATE TABLE public.ger_marca_x_ger_modelo (
    n_cod_marca integer,
    n_cod_modelo integer
);
 *   DROP TABLE public.ger_marca_x_ger_modelo;
       public         heap    postgres    false         �            1259    16412 
   ger_modelo    TABLE     m   CREATE TABLE public.ger_modelo (
    n_cod_modelo integer NOT NULL,
    c_descricao character varying(60)
);
    DROP TABLE public.ger_modelo;
       public         heap    postgres    false         �            1259    16436    ger_modelo_n_cod_modelo_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_modelo_n_cod_modelo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.ger_modelo_n_cod_modelo_seq;
       public          postgres    false    205         L           0    0    ger_modelo_n_cod_modelo_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.ger_modelo_n_cod_modelo_seq OWNED BY public.ger_modelo.n_cod_modelo;
          public          postgres    false    210         �            1259    24610 	   ger_posto    TABLE     l   CREATE TABLE public.ger_posto (
    n_cod_posto integer NOT NULL,
    c_descricao character varying(100)
);
    DROP TABLE public.ger_posto;
       public         heap    postgres    false         �            1259    24613    ger_posto_n_cod_posto_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_posto_n_cod_posto_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public.ger_posto_n_cod_posto_seq;
       public          postgres    false    216         M           0    0    ger_posto_n_cod_posto_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.ger_posto_n_cod_posto_seq OWNED BY public.ger_posto.n_cod_posto;
          public          postgres    false    217         �            1259    16415    ger_tipo_combustivel    TABLE     �   CREATE TABLE public.ger_tipo_combustivel (
    n_cod_combustivel integer NOT NULL,
    c_descricao character varying(60) NOT NULL
);
 (   DROP TABLE public.ger_tipo_combustivel;
       public         heap    postgres    false         �            1259    16442 *   ger_tipo_combustivel_n_cod_combustivel_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_tipo_combustivel_n_cod_combustivel_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 A   DROP SEQUENCE public.ger_tipo_combustivel_n_cod_combustivel_seq;
       public          postgres    false    206         N           0    0 *   ger_tipo_combustivel_n_cod_combustivel_seq    SEQUENCE OWNED BY     y   ALTER SEQUENCE public.ger_tipo_combustivel_n_cod_combustivel_seq OWNED BY public.ger_tipo_combustivel.n_cod_combustivel;
          public          postgres    false    211         �            1259    16418    ger_tipo_veiculo    TABLE     y   CREATE TABLE public.ger_tipo_veiculo (
    n_cod_tipo_veiculo integer NOT NULL,
    c_descricao character varying(60)
);
 $   DROP TABLE public.ger_tipo_veiculo;
       public         heap    postgres    false         �            1259    16448 '   ger_tipo_veiculo_n_cod_tipo_veiculo_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq;
       public          postgres    false    207         O           0    0 '   ger_tipo_veiculo_n_cod_tipo_veiculo_seq    SEQUENCE OWNED BY     s   ALTER SEQUENCE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq OWNED BY public.ger_tipo_veiculo.n_cod_tipo_veiculo;
          public          postgres    false    212         �            1259    16397    ger_usuario    TABLE     �   CREATE TABLE public.ger_usuario (
    n_cod_usuario integer NOT NULL,
    c_nome character varying(100) NOT NULL,
    c_senha character varying(40) NOT NULL,
    c_email character varying(100)
);
    DROP TABLE public.ger_usuario;
       public         heap    postgres    false         �            1259    16400    ger_usuario_n_cod_usuario_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_usuario_n_cod_usuario_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public.ger_usuario_n_cod_usuario_seq;
       public          postgres    false    202         P           0    0    ger_usuario_n_cod_usuario_seq    SEQUENCE OWNED BY     _   ALTER SEQUENCE public.ger_usuario_n_cod_usuario_seq OWNED BY public.ger_usuario.n_cod_usuario;
          public          postgres    false    203         �            1259    16421    ger_veiculo    TABLE     0  CREATE TABLE public.ger_veiculo (
    n_cod_veiculo integer NOT NULL,
    n_cod_marca integer NOT NULL,
    n_cod_modelo integer,
    c_placa character varying(7),
    n_cod_tipo_veiculo integer,
    n_cod_combustivel integer,
    n_quilometragem integer,
    n_cod_usuario integer,
    d_ano integer
);
    DROP TABLE public.ger_veiculo;
       public         heap    postgres    false         �            1259    16454    ger_veiculo_n_cod_veiculo_seq    SEQUENCE     �   CREATE SEQUENCE public.ger_veiculo_n_cod_veiculo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public.ger_veiculo_n_cod_veiculo_seq;
       public          postgres    false    208         Q           0    0    ger_veiculo_n_cod_veiculo_seq    SEQUENCE OWNED BY     _   ALTER SEQUENCE public.ger_veiculo_n_cod_veiculo_seq OWNED BY public.ger_veiculo.n_cod_veiculo;
          public          postgres    false    213         �
           2604    32799 %   ger_abastecimento n_cod_abastecimento    DEFAULT     �   ALTER TABLE ONLY public.ger_abastecimento ALTER COLUMN n_cod_abastecimento SET DEFAULT nextval('public.ger_abastecimento_n_cod_abastecimento_seq'::regclass);
 T   ALTER TABLE public.ger_abastecimento ALTER COLUMN n_cod_abastecimento DROP DEFAULT;
       public          postgres    false    218    215         �
           2604    16432    ger_marca n_cod_marca    DEFAULT     ~   ALTER TABLE ONLY public.ger_marca ALTER COLUMN n_cod_marca SET DEFAULT nextval('public.ger_marca_n_cod_marca_seq'::regclass);
 D   ALTER TABLE public.ger_marca ALTER COLUMN n_cod_marca DROP DEFAULT;
       public          postgres    false    209    204         �
           2604    16438    ger_modelo n_cod_modelo    DEFAULT     �   ALTER TABLE ONLY public.ger_modelo ALTER COLUMN n_cod_modelo SET DEFAULT nextval('public.ger_modelo_n_cod_modelo_seq'::regclass);
 F   ALTER TABLE public.ger_modelo ALTER COLUMN n_cod_modelo DROP DEFAULT;
       public          postgres    false    210    205         �
           2604    24615    ger_posto n_cod_posto    DEFAULT     ~   ALTER TABLE ONLY public.ger_posto ALTER COLUMN n_cod_posto SET DEFAULT nextval('public.ger_posto_n_cod_posto_seq'::regclass);
 D   ALTER TABLE public.ger_posto ALTER COLUMN n_cod_posto DROP DEFAULT;
       public          postgres    false    217    216         �
           2604    16444 &   ger_tipo_combustivel n_cod_combustivel    DEFAULT     �   ALTER TABLE ONLY public.ger_tipo_combustivel ALTER COLUMN n_cod_combustivel SET DEFAULT nextval('public.ger_tipo_combustivel_n_cod_combustivel_seq'::regclass);
 U   ALTER TABLE public.ger_tipo_combustivel ALTER COLUMN n_cod_combustivel DROP DEFAULT;
       public          postgres    false    211    206         �
           2604    16450 #   ger_tipo_veiculo n_cod_tipo_veiculo    DEFAULT     �   ALTER TABLE ONLY public.ger_tipo_veiculo ALTER COLUMN n_cod_tipo_veiculo SET DEFAULT nextval('public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq'::regclass);
 R   ALTER TABLE public.ger_tipo_veiculo ALTER COLUMN n_cod_tipo_veiculo DROP DEFAULT;
       public          postgres    false    212    207         �
           2604    16402    ger_usuario n_cod_usuario    DEFAULT     �   ALTER TABLE ONLY public.ger_usuario ALTER COLUMN n_cod_usuario SET DEFAULT nextval('public.ger_usuario_n_cod_usuario_seq'::regclass);
 H   ALTER TABLE public.ger_usuario ALTER COLUMN n_cod_usuario DROP DEFAULT;
       public          postgres    false    203    202         �
           2604    16456    ger_veiculo n_cod_veiculo    DEFAULT     �   ALTER TABLE ONLY public.ger_veiculo ALTER COLUMN n_cod_veiculo SET DEFAULT nextval('public.ger_veiculo_n_cod_veiculo_seq'::regclass);
 H   ALTER TABLE public.ger_veiculo ALTER COLUMN n_cod_veiculo DROP DEFAULT;
       public          postgres    false    213    208         @          0    24601    ger_abastecimento 
   TABLE DATA           �   COPY public.ger_abastecimento (n_km_abastecimento, n_litro_abastecimento, v_vlr_pago, d_abastecimento, n_cod_posto, n_cod_usuario, n_cod_combustivel, n_cod_veiculo, n_cod_tipo_veiculo, n_cod_abastecimento) FROM stdin;
    public          postgres    false    215       2880.dat 5          0    16409 	   ger_marca 
   TABLE DATA           =   COPY public.ger_marca (n_cod_marca, c_descricao) FROM stdin;
    public          postgres    false    204       2869.dat ?          0    16460    ger_marca_x_ger_modelo 
   TABLE DATA           K   COPY public.ger_marca_x_ger_modelo (n_cod_marca, n_cod_modelo) FROM stdin;
    public          postgres    false    214       2879.dat 6          0    16412 
   ger_modelo 
   TABLE DATA           ?   COPY public.ger_modelo (n_cod_modelo, c_descricao) FROM stdin;
    public          postgres    false    205       2870.dat A          0    24610 	   ger_posto 
   TABLE DATA           =   COPY public.ger_posto (n_cod_posto, c_descricao) FROM stdin;
    public          postgres    false    216       2881.dat 7          0    16415    ger_tipo_combustivel 
   TABLE DATA           N   COPY public.ger_tipo_combustivel (n_cod_combustivel, c_descricao) FROM stdin;
    public          postgres    false    206       2871.dat 8          0    16418    ger_tipo_veiculo 
   TABLE DATA           K   COPY public.ger_tipo_veiculo (n_cod_tipo_veiculo, c_descricao) FROM stdin;
    public          postgres    false    207       2872.dat 3          0    16397    ger_usuario 
   TABLE DATA           N   COPY public.ger_usuario (n_cod_usuario, c_nome, c_senha, c_email) FROM stdin;
    public          postgres    false    202       2867.dat 9          0    16421    ger_veiculo 
   TABLE DATA           �   COPY public.ger_veiculo (n_cod_veiculo, n_cod_marca, n_cod_modelo, c_placa, n_cod_tipo_veiculo, n_cod_combustivel, n_quilometragem, n_cod_usuario, d_ano) FROM stdin;
    public          postgres    false    208       2873.dat R           0    0 )   ger_abastecimento_n_cod_abastecimento_seq    SEQUENCE SET     W   SELECT pg_catalog.setval('public.ger_abastecimento_n_cod_abastecimento_seq', 9, true);
          public          postgres    false    218         S           0    0    ger_marca_n_cod_marca_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.ger_marca_n_cod_marca_seq', 6, true);
          public          postgres    false    209         T           0    0    ger_modelo_n_cod_modelo_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.ger_modelo_n_cod_modelo_seq', 11, true);
          public          postgres    false    210         U           0    0    ger_posto_n_cod_posto_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.ger_posto_n_cod_posto_seq', 1, true);
          public          postgres    false    217         V           0    0 *   ger_tipo_combustivel_n_cod_combustivel_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('public.ger_tipo_combustivel_n_cod_combustivel_seq', 2, true);
          public          postgres    false    211         W           0    0 '   ger_tipo_veiculo_n_cod_tipo_veiculo_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq', 2, true);
          public          postgres    false    212         X           0    0    ger_usuario_n_cod_usuario_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public.ger_usuario_n_cod_usuario_seq', 2, true);
          public          postgres    false    203         Y           0    0    ger_veiculo_n_cod_veiculo_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public.ger_veiculo_n_cod_veiculo_seq', 5, true);
          public          postgres    false    213                                                                                                                                                                                                                                                                         2880.dat                                                                                            0000600 0004000 0002000 00000000500 13716745116 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	10	30	2020-08-17	1	1	1	1	1	1
39	46.3	35.85	2020-08-18	1	0	2	2	2	4
45	25	24	2020-08-11	1	1	1	1	1	2
48.51	48.88	253	2020-08-28	1	1	1	4	2	5
234.93	23.34	25.55	2020-08-17	1	2	2	5	1	6
123.33	1233.33	13.33	2019-08-16	1	1	2	2	1	7
154.78	1548.84	234.44	2020-07-15	1	1	2	4	1	8
23455.55	12.33	123.33	2020-05-05	1	1	2	2	1	9
\.


                                                                                                                                                                                                2869.dat                                                                                            0000600 0004000 0002000 00000000100 13716745116 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Volkswagen
2	Ford
3	chevrolet
4	Honda
5	Yamaha
6	hyundai
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                2879.dat                                                                                            0000600 0004000 0002000 00000000067 13716745116 0014301 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	1
1	1
2	7
2	8
3	3
3	4
4	10
4	11
6	5
6	6
5	9
1	2
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                         2870.dat                                                                                            0000600 0004000 0002000 00000000152 13716745116 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Gol
2	Golf
3	Onix
4	S10
5	HB20
6	HB20 S
7	Fiesta Sedan
8	New Fiesta
9	Fazer 250
10	CB300
11	CG 150
\.


                                                                                                                                                                                                                                                                                                                                                                                                                      2881.dat                                                                                            0000600 0004000 0002000 00000000023 13716745116 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	POSTO SHEEL
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             2871.dat                                                                                            0000600 0004000 0002000 00000000031 13716745116 0014260 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Gasolina
2	Alcool
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       2872.dat                                                                                            0000600 0004000 0002000 00000000024 13716745116 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Carro
2	Moto
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            2867.dat                                                                                            0000600 0004000 0002000 00000000070 13716745116 0014270 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	Gustao Barreto	123	g.com
1	Gustavo	123	teste.com
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                        2873.dat                                                                                            0000600 0004000 0002000 00000000142 13716745116 0014265 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	2	7	ECS2344	1	2	12313	1	1992
1	1	1	ECS2523	1	1	39233	1	2016
5	2	7	ECS2523	2	2	13594	2	2013
\.


                                                                                                                                                                                                                                                                                                                                                                                                                              restore.sql                                                                                         0000600 0004000 0002000 00000034170 13716745117 0015405 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE bd_bitzen;
--
-- Name: bd_bitzen; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE bd_bitzen WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Portuguese_Brazil.1252' LC_CTYPE = 'Portuguese_Brazil.1252';


ALTER DATABASE bd_bitzen OWNER TO postgres;

\connect bd_bitzen

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: ger_abastecimento; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_abastecimento (
    n_km_abastecimento double precision,
    n_litro_abastecimento double precision,
    v_vlr_pago double precision,
    d_abastecimento date,
    n_cod_posto integer,
    n_cod_usuario integer,
    n_cod_combustivel integer,
    n_cod_veiculo integer,
    n_cod_tipo_veiculo integer,
    n_cod_abastecimento integer NOT NULL
);


ALTER TABLE public.ger_abastecimento OWNER TO postgres;

--
-- Name: ger_abastecimento_n_cod_abastecimento_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_abastecimento_n_cod_abastecimento_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_abastecimento_n_cod_abastecimento_seq OWNER TO postgres;

--
-- Name: ger_abastecimento_n_cod_abastecimento_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_abastecimento_n_cod_abastecimento_seq OWNED BY public.ger_abastecimento.n_cod_abastecimento;


--
-- Name: ger_marca; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_marca (
    n_cod_marca integer NOT NULL,
    c_descricao character varying(60)
);


ALTER TABLE public.ger_marca OWNER TO postgres;

--
-- Name: ger_marca_n_cod_marca_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_marca_n_cod_marca_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_marca_n_cod_marca_seq OWNER TO postgres;

--
-- Name: ger_marca_n_cod_marca_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_marca_n_cod_marca_seq OWNED BY public.ger_marca.n_cod_marca;


--
-- Name: ger_marca_x_ger_modelo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_marca_x_ger_modelo (
    n_cod_marca integer,
    n_cod_modelo integer
);


ALTER TABLE public.ger_marca_x_ger_modelo OWNER TO postgres;

--
-- Name: ger_modelo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_modelo (
    n_cod_modelo integer NOT NULL,
    c_descricao character varying(60)
);


ALTER TABLE public.ger_modelo OWNER TO postgres;

--
-- Name: ger_modelo_n_cod_modelo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_modelo_n_cod_modelo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_modelo_n_cod_modelo_seq OWNER TO postgres;

--
-- Name: ger_modelo_n_cod_modelo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_modelo_n_cod_modelo_seq OWNED BY public.ger_modelo.n_cod_modelo;


--
-- Name: ger_posto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_posto (
    n_cod_posto integer NOT NULL,
    c_descricao character varying(100)
);


ALTER TABLE public.ger_posto OWNER TO postgres;

--
-- Name: ger_posto_n_cod_posto_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_posto_n_cod_posto_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_posto_n_cod_posto_seq OWNER TO postgres;

--
-- Name: ger_posto_n_cod_posto_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_posto_n_cod_posto_seq OWNED BY public.ger_posto.n_cod_posto;


--
-- Name: ger_tipo_combustivel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_tipo_combustivel (
    n_cod_combustivel integer NOT NULL,
    c_descricao character varying(60) NOT NULL
);


ALTER TABLE public.ger_tipo_combustivel OWNER TO postgres;

--
-- Name: ger_tipo_combustivel_n_cod_combustivel_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_tipo_combustivel_n_cod_combustivel_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_tipo_combustivel_n_cod_combustivel_seq OWNER TO postgres;

--
-- Name: ger_tipo_combustivel_n_cod_combustivel_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_tipo_combustivel_n_cod_combustivel_seq OWNED BY public.ger_tipo_combustivel.n_cod_combustivel;


--
-- Name: ger_tipo_veiculo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_tipo_veiculo (
    n_cod_tipo_veiculo integer NOT NULL,
    c_descricao character varying(60)
);


ALTER TABLE public.ger_tipo_veiculo OWNER TO postgres;

--
-- Name: ger_tipo_veiculo_n_cod_tipo_veiculo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq OWNER TO postgres;

--
-- Name: ger_tipo_veiculo_n_cod_tipo_veiculo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq OWNED BY public.ger_tipo_veiculo.n_cod_tipo_veiculo;


--
-- Name: ger_usuario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_usuario (
    n_cod_usuario integer NOT NULL,
    c_nome character varying(100) NOT NULL,
    c_senha character varying(40) NOT NULL,
    c_email character varying(100)
);


ALTER TABLE public.ger_usuario OWNER TO postgres;

--
-- Name: ger_usuario_n_cod_usuario_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_usuario_n_cod_usuario_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_usuario_n_cod_usuario_seq OWNER TO postgres;

--
-- Name: ger_usuario_n_cod_usuario_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_usuario_n_cod_usuario_seq OWNED BY public.ger_usuario.n_cod_usuario;


--
-- Name: ger_veiculo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ger_veiculo (
    n_cod_veiculo integer NOT NULL,
    n_cod_marca integer NOT NULL,
    n_cod_modelo integer,
    c_placa character varying(7),
    n_cod_tipo_veiculo integer,
    n_cod_combustivel integer,
    n_quilometragem integer,
    n_cod_usuario integer,
    d_ano integer
);


ALTER TABLE public.ger_veiculo OWNER TO postgres;

--
-- Name: ger_veiculo_n_cod_veiculo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ger_veiculo_n_cod_veiculo_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ger_veiculo_n_cod_veiculo_seq OWNER TO postgres;

--
-- Name: ger_veiculo_n_cod_veiculo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ger_veiculo_n_cod_veiculo_seq OWNED BY public.ger_veiculo.n_cod_veiculo;


--
-- Name: ger_abastecimento n_cod_abastecimento; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_abastecimento ALTER COLUMN n_cod_abastecimento SET DEFAULT nextval('public.ger_abastecimento_n_cod_abastecimento_seq'::regclass);


--
-- Name: ger_marca n_cod_marca; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_marca ALTER COLUMN n_cod_marca SET DEFAULT nextval('public.ger_marca_n_cod_marca_seq'::regclass);


--
-- Name: ger_modelo n_cod_modelo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_modelo ALTER COLUMN n_cod_modelo SET DEFAULT nextval('public.ger_modelo_n_cod_modelo_seq'::regclass);


--
-- Name: ger_posto n_cod_posto; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_posto ALTER COLUMN n_cod_posto SET DEFAULT nextval('public.ger_posto_n_cod_posto_seq'::regclass);


--
-- Name: ger_tipo_combustivel n_cod_combustivel; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_tipo_combustivel ALTER COLUMN n_cod_combustivel SET DEFAULT nextval('public.ger_tipo_combustivel_n_cod_combustivel_seq'::regclass);


--
-- Name: ger_tipo_veiculo n_cod_tipo_veiculo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_tipo_veiculo ALTER COLUMN n_cod_tipo_veiculo SET DEFAULT nextval('public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq'::regclass);


--
-- Name: ger_usuario n_cod_usuario; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_usuario ALTER COLUMN n_cod_usuario SET DEFAULT nextval('public.ger_usuario_n_cod_usuario_seq'::regclass);


--
-- Name: ger_veiculo n_cod_veiculo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ger_veiculo ALTER COLUMN n_cod_veiculo SET DEFAULT nextval('public.ger_veiculo_n_cod_veiculo_seq'::regclass);


--
-- Data for Name: ger_abastecimento; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_abastecimento (n_km_abastecimento, n_litro_abastecimento, v_vlr_pago, d_abastecimento, n_cod_posto, n_cod_usuario, n_cod_combustivel, n_cod_veiculo, n_cod_tipo_veiculo, n_cod_abastecimento) FROM stdin;
\.
COPY public.ger_abastecimento (n_km_abastecimento, n_litro_abastecimento, v_vlr_pago, d_abastecimento, n_cod_posto, n_cod_usuario, n_cod_combustivel, n_cod_veiculo, n_cod_tipo_veiculo, n_cod_abastecimento) FROM '$$PATH$$/2880.dat';

--
-- Data for Name: ger_marca; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_marca (n_cod_marca, c_descricao) FROM stdin;
\.
COPY public.ger_marca (n_cod_marca, c_descricao) FROM '$$PATH$$/2869.dat';

--
-- Data for Name: ger_marca_x_ger_modelo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_marca_x_ger_modelo (n_cod_marca, n_cod_modelo) FROM stdin;
\.
COPY public.ger_marca_x_ger_modelo (n_cod_marca, n_cod_modelo) FROM '$$PATH$$/2879.dat';

--
-- Data for Name: ger_modelo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_modelo (n_cod_modelo, c_descricao) FROM stdin;
\.
COPY public.ger_modelo (n_cod_modelo, c_descricao) FROM '$$PATH$$/2870.dat';

--
-- Data for Name: ger_posto; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_posto (n_cod_posto, c_descricao) FROM stdin;
\.
COPY public.ger_posto (n_cod_posto, c_descricao) FROM '$$PATH$$/2881.dat';

--
-- Data for Name: ger_tipo_combustivel; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_tipo_combustivel (n_cod_combustivel, c_descricao) FROM stdin;
\.
COPY public.ger_tipo_combustivel (n_cod_combustivel, c_descricao) FROM '$$PATH$$/2871.dat';

--
-- Data for Name: ger_tipo_veiculo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_tipo_veiculo (n_cod_tipo_veiculo, c_descricao) FROM stdin;
\.
COPY public.ger_tipo_veiculo (n_cod_tipo_veiculo, c_descricao) FROM '$$PATH$$/2872.dat';

--
-- Data for Name: ger_usuario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_usuario (n_cod_usuario, c_nome, c_senha, c_email) FROM stdin;
\.
COPY public.ger_usuario (n_cod_usuario, c_nome, c_senha, c_email) FROM '$$PATH$$/2867.dat';

--
-- Data for Name: ger_veiculo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ger_veiculo (n_cod_veiculo, n_cod_marca, n_cod_modelo, c_placa, n_cod_tipo_veiculo, n_cod_combustivel, n_quilometragem, n_cod_usuario, d_ano) FROM stdin;
\.
COPY public.ger_veiculo (n_cod_veiculo, n_cod_marca, n_cod_modelo, c_placa, n_cod_tipo_veiculo, n_cod_combustivel, n_quilometragem, n_cod_usuario, d_ano) FROM '$$PATH$$/2873.dat';

--
-- Name: ger_abastecimento_n_cod_abastecimento_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_abastecimento_n_cod_abastecimento_seq', 9, true);


--
-- Name: ger_marca_n_cod_marca_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_marca_n_cod_marca_seq', 6, true);


--
-- Name: ger_modelo_n_cod_modelo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_modelo_n_cod_modelo_seq', 11, true);


--
-- Name: ger_posto_n_cod_posto_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_posto_n_cod_posto_seq', 1, true);


--
-- Name: ger_tipo_combustivel_n_cod_combustivel_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_tipo_combustivel_n_cod_combustivel_seq', 2, true);


--
-- Name: ger_tipo_veiculo_n_cod_tipo_veiculo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_tipo_veiculo_n_cod_tipo_veiculo_seq', 2, true);


--
-- Name: ger_usuario_n_cod_usuario_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_usuario_n_cod_usuario_seq', 2, true);


--
-- Name: ger_veiculo_n_cod_veiculo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ger_veiculo_n_cod_veiculo_seq', 5, true);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        