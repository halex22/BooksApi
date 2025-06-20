PGDMP  #        
            }           books    17.5    17.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    73728    books    DATABASE     x   CREATE DATABASE books WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Italian_Italy.1252';
    DROP DATABASE books;
                     postgres    false            �            1259    73735    book    TABLE     .  CREATE TABLE public.book (
    id integer NOT NULL,
    title character varying(250) NOT NULL,
    img character varying(2000),
    author character varying(100),
    publish_date date NOT NULL,
    is_available boolean DEFAULT true NOT NULL,
    category_id integer NOT NULL
);
    DROP TABLE public.book;
       public         heap r       postgres    false            �            1259    73734    book_id_seq    SEQUENCE     �   CREATE SEQUENCE public.book_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.book_id_seq;
       public               postgres    false    218            �           0    0    book_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.book_id_seq OWNED BY public.book.id;
          public               postgres    false    217            �            1259    73745    category    TABLE     d   CREATE TABLE public.category (
    id integer NOT NULL,
    name character varying(150) NOT NULL
);
    DROP TABLE public.category;
       public         heap r       postgres    false            �            1259    73744    category_id_seq    SEQUENCE     �   CREATE SEQUENCE public.category_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.category_id_seq;
       public               postgres    false    220                        0    0    category_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.category_id_seq OWNED BY public.category.id;
          public               postgres    false    219            \           2604    73738    book id    DEFAULT     b   ALTER TABLE ONLY public.book ALTER COLUMN id SET DEFAULT nextval('public.book_id_seq'::regclass);
 6   ALTER TABLE public.book ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    217    218    218            ^           2604    73748    category id    DEFAULT     j   ALTER TABLE ONLY public.category ALTER COLUMN id SET DEFAULT nextval('public.category_id_seq'::regclass);
 :   ALTER TABLE public.category ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    220    219    220            �          0    73735    book 
   TABLE DATA           _   COPY public.book (id, title, img, author, publish_date, is_available, category_id) FROM stdin;
    public               postgres    false    218   �       �          0    73745    category 
   TABLE DATA           ,   COPY public.category (id, name) FROM stdin;
    public               postgres    false    220   b                  0    0    book_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.book_id_seq', 30, true);
          public               postgres    false    217                       0    0    category_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.category_id_seq', 5, true);
          public               postgres    false    219            `           2606    73743    book book_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.book DROP CONSTRAINT book_pkey;
       public                 postgres    false    218            b           2606    73750    category category_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.category DROP CONSTRAINT category_pkey;
       public                 postgres    false    220            c           2606    73751    book book_cat_fk 
   FK CONSTRAINT     �   ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_cat_fk FOREIGN KEY (category_id) REFERENCES public.category(id) NOT VALID;
 :   ALTER TABLE ONLY public.book DROP CONSTRAINT book_cat_fk;
       public               postgres    false    218    220    4706            �   �  x�}V�n�6}��b�ڗ�)_�����&���h���H�AJ���;�����EΌ�ϙ9%�B�WmkX��.IQ�;{~v&~�jW�a������Ώ�\s�F�a1��x�1��<v��&t�ȧM��Zl���z�7�����0q�,b1P���	�4Rl�Bٽ0j
5�~)s�����V6Xk�Ky��/��Ů
n��Y��-����o%���,�N����y��/�^�A
7�a��x���<�0G��'�V�ײ�>�Q?�V�|�J�Γi�#F!���x0!��0J�d��[�uA<��6%��r����Nf�(K�ּ��4�I�`F.lm��8X�Y�jB#"Hnc�b�=�+�Y�F,�V��`�?�ԝ f@�=��d�(�,�����
��"<�y������k�+�6H���}�
hLP]s�]��xl7�Km2a���b)�DX��D�2�G�/�m�I�&�%��\�\�~�kQ�m�sҍ���p�7�Na��.J����2�o���'�������/K�
�Kn���Jr���J\j�Koa%���9i�	�����ȫ���#B��I�:>^��,u�]�㈍���ڶ�y�+��u�>Iv/�I������̞QӺ�6��ǇM�D��k����*!���y�Iw.磬�mY�F�K֩���ȼ�].����f�s�u�s�'�y��οz��ȕ��Cg>���)a�s�k;�r=���s��r|?J4�0f�)���Um��/�ea���heEg�nғ��8��N�Uap;�Ur�2������qSK��}g�hI%ߐJ�j�h�S�f����KF�+�Y���.���/�[�֋�Fjoag���a�K�P|*�P�w%��=mR�tI��1��0B��!sM-"�*���s����B���:I����/r�_��}����}�Q�v;��/�m��h�C�L�v�#9�kK��#��וY�]�W���Ѧ6�7mR�풎�E������w�N��k��F��+^s���zs�	����2{������;N�j[���[��������D#�>��c���+�UW����SR��-<7k�v�j���N0q�x���&1�M�z�Mx��.xRV����u������Sc      �   @   x�3�N��u��2�����M�L.����2	��%�r�pzd��Ur�r�%�$Wr��qqq ���     