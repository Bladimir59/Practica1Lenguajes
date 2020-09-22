using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace practicaLenguajes1
{
    class Analisar
    {
        int contador=0;
        char[] caracter;
        String mostrar="";
        Boolean valido;
        int error;
        public string EstadoInicial(string cadena)
        {
            caracter = cadena.ToCharArray();
            valido = false;
            Estado0();
            return mostrar;
        }
        public void Estado0()
        {
            if (contador < caracter.Length)
            {
                int codigo = (int)caracter[contador];
                if ((codigo >= 48 && codigo <= 57) || codigo == 45)//acapara todo los digitos un entero o decimal
                {
                    contador++;
                    Estadol();
                } else if (codigo == 42 || codigo == 43 || codigo == 45 || codigo == 47)//para operadores artimeticos
                {
                    contador++;
                    AcetacionSignos();
                } else if (codigo == 118)  //llamar la v de verdadero de un boolean
                {
                    contador++;
                    Estado4();
                } else if (codigo == 102)  //llamar la f de falso de boolena
                {
                    contador++;
                    Estadol2();
                } else if (codigo == 60 || codigo == 62)//para operadores relacionales
                {
                    contador++;
                    AceptacionOperador();
                } else if (codigo == 34)//cadena
                {
                    contador++;
                    Estadol6();
                } else if (codigo == 65 || codigo == 97 || codigo == 66 || codigo == 105)//para char
                {
                    contador++;
                    AceptacionChar();
                } else if (codigo==38 || codigo==124||codigo==33)//operadores logicos
                {
                    contador++;
                    AceptacionLogico();
                }else if (codigo==40||codigo==41)//para signos de agrupacion
                {
                    contador++;
                    AceptacionAgrupacion();
                }else if (codigo==61||codigo==59)//para signos de sentencia
                {
                    contador++;
                    AceptacionSentencia();
                }else if (codigo==47)//comentarios
                {
                    contador++;
                    Estadol7();
                }
                else if (codigo==83)//para palabras reservadas con s inicial
                {
                    contador++;
                    Estado20();
                }
                else if (codigo == 77)//para palabras reservadas con m inicial
                {
                    contador++;

                }
                else if (codigo==72)//para palabras reservadas con h inicial
                {
                    contador++;

                }
                else if (codigo==68)//para palabras reservadas con d inicial
                {
                    contador++;

                }
                else if (codigo==73)//para palabras reservadas con i inicial
                {
                    contador++;
                }
                else
                {
                    Error();
                }
                
            }
        }
        public void Estadol()//para digito
        {
            mostrar = mostrar + caracter[contador-1];
            Digito llamar = new Digito();
            if (contador < caracter.Length)
            {
                if (llamar.VerificarDigito(caracter[contador]) == true)
                {
                    contador++;
                    Estadol();
                }else if (caracter[contador] == '.')
                {
                    contador++;
                    Estado2();
                }

                else
                {
                    contador++;
                    Error();
                    //estado de aceptacion
                }
            }
        }
        public void Estado2()
        {
            mostrar = mostrar + caracter[contador-1];
            Digito llamar = new Digito();
            if (contador < caracter.Length)
            {
                if (llamar.VerificarDigito(caracter[contador]) == true)
                {
                    contador++;
                    Estado2();
                }
                else
                {
                    //pintar
                    contador++;
                    Error();
                    //estado de aceptacion
                }
            }
        }
        public void Estado3()//final de digito o decimal
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == '"')
                {
                    contador++;
                    Aceptacion();
                }
                else
                {
                    contador++;
                    Estado3();
                }

            }
        }
        public void Estado4() //para verdadero de boolena
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'e')
                {
                    contador++;
                    Estado5();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado5()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'r')
                {
                    contador++;
                    Estado6();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado6()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'd')
                {
                    contador++;
                    Estado7();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado7()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'a')
                {
                    contador++;
                    Estado8();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado8()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'd')
                {
                    contador++;
                    Estado9();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado9()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'e')
                {
                    contador++;
                    Estadol0();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estadol0()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'r')
                {
                    contador++;
                    Estadol1();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estadol1()//final de verdadero
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'o')
                {
                    contador++;
                    AceptacionBoolean();
                }
            }
        }
        public void Estadol2() //falso
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'a')
                {
                    contador++;
                    Estadol3();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estadol3()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'l')
                {
                    contador++;
                    Estadol4();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estadol4()
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 's')
                {
                    contador++;
                    Estadol5();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estadol5()//final para falso
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'o')
                {
                    contador++;
                    AceptacionBoolean();
                }
                else
                {
                    Error();
                }
            }
        }
        public void Estadol6()//para las cadenas
        {
            mostrar = mostrar + caracter[contador-1];
            if (contador < caracter.Length)
            {
                if ((int)caracter[contador] == 34)
                {
                    //llmar aceptacion de cadena
                    contador++;
                    AceptacionCadena();
                }
                else
                {
                    contador++;
                    Estadol6();
                }
            }
        }
        public void Estadol7()//para comentarios
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador-1];
            if (contador < caracter.Length)
            {
                if (codigo == 47 || codigo == 42)
                {
                    contador++;
                    Estadol8();
                }
                else
                {
                    Error();
                }
            }
        }
        public void Estadol8()
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador - 1];
            if (contador < caracter.Length)
            {
                if (codigo==(int)'\n')
                {
                    contador++;
                    AceptacionComentario();
                }else if (codigo==42)
                {
                    contador++;
                    Estadol9();
                }
                else
                {
                    contador++;
                    Estadol8();
                }
            }
        }
        public void Estadol9()//final para comentarios
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador - 1];
            if (contador < caracter.Length)
            {
                 if (codigo == 47)
                {
                    contador++;
                    AceptacionComentario(); ;
                }
                else
                {
                    contador++;
                    Estadol8();
                }
            }
        }
        public void Estado20()//inicio para palabras reservadas
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador];
            if (contador < caracter.Length)
            {
                if (caracter[contador]=='I')
                {
                    contador++;
                    AceptacionPalabra();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado2l()
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador - 1];
            if (contador < caracter.Length)
            {
                if(caracter[contador] == 'O')
                {
                    contador++;
                    AceptacionPalabra();
                }
                else
                {
                    contador++;
                    Error();
                }
            }
        }
        public void Estado22()//para el guin bajo de sino_si
        {
            mostrar = mostrar + caracter[contador - 1];
            int codigo = (int)caracter[contador - 1];
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'S')
                {
                    contador++;
                    Estado20();
                }
                else
                {
                    Error();
                }
            }
        }
        public void Estado23()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado24()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado25()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado26()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado27()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado28()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado29()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado30()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado3l()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado32()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado33()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado34()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado35()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado36()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado37()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Estado38()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void AceptacionPalabra()
        {
            int codigo = (int)caracter[contador-1];
            mostrar = mostrar + caracter[contador - 1] + " palabra reservada\n";
            if (contador < caracter.Length)
            {
                if (caracter[contador] == 'N')
                {
                    contador++;
                    Estado2l();
                } else if (caracter[contador] == '_') {
                    contador++;
                    Estado22();
                }
                if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    contador++;
                    Estado0();
                }
                
            }
        }
        public void AceptacionComentario()
        {
            int codigo = (int)caracter[contador];
            mostrar = mostrar + caracter[contador - 1] + " comentario\n";
            if (contador < caracter.Length)
            {
                if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionCadena()
        {
            int codigo = 0;
            codigo = (int)caracter[contador-1];
            mostrar = mostrar + caracter[contador-1]+" llego a cadena\n";
            if (contador < caracter.Length)
            {
                //pintar
                if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionBoolean()
        {
            int codigo = 0;
            codigo= (int)caracter[contador-1];
            mostrar =mostrar+caracter[contador-1]+" boolean\n";
            if (contador < caracter.Length)
            {
                //pintar
                if (codigo==32||codigo==(int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void PalabraReservada()
        {
            if (contador < caracter.Length)
            {

            }
        }
        public void Comentarios()
        {
            
        }
        public void AceptacionAgrupacion()//agrupacion ()
        {
            int codigo = 0;
            codigo = (int)caracter[contador - 1];
            mostrar = mostrar + caracter[contador - 1] + " agrupacion\n";
            if (contador < caracter.Length)
            {
                 if (codigo == 40||codigo==41)
                {
                    contador++;
                    AceptacionAgrupacion();
                }
                else if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionSentencia()
        {
            int codigo = (int)caracter[contador-1];
            mostrar = mostrar + caracter[contador-1]+" sentencia\n";
            if (contador < caracter.Length)
            {
                if (codigo==61)
                {
                    contador++;
                    AceptacionOperador();
                }
                else if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionLogico()
        {
            int codigo = 0;
            codigo = (int)caracter[contador - 1];
            mostrar = mostrar + caracter[contador - 1] + " operador\n";
            if (contador < caracter.Length)
            {
                //pintar
                if (codigo==38||codigo==124)
                {
                    contador++;
                    AceptacionLogico();
                }else if (codigo==61)
                {
                    contador++;
                    AceptacionOperador();
                }else if (codigo == 32 || codigo == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionChar()
        {
            int codigo = 0;
            codigo = (int)caracter[contador-1];
            mostrar = mostrar + caracter[contador - 1]+" char\n";
            if (contador < caracter.Length)
            {
                //pintar
                if (codigo == 65 || codigo == 97 || codigo == 66 || codigo == 105)
                {
                    contador++;
                    AceptacionChar();
                }else //pintar
                if (codigo==32||codigo==(int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
            }
        }
        public void AceptacionOperador()
        {
            int codigo = (int)caracter[contador];
            mostrar = mostrar + caracter[contador - 1]+" agrupacion\n";
            if (contador < caracter.Length)
            {
                if (codigo==61)
                {
                    contador++;
                    AceptacionOperador();
                }
                else if (contador == 32 || contador == (int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }

            }
        }
        public void AcetacionSignos()
        {
            int codigo = (int)caracter[contador-1];
            mostrar = mostrar + caracter[contador-1]+" signo\n";

            if (contador < caracter.Length)
            {
                if (codigo==43||codigo==45)
                {
                    contador++;
                    AcetacionSignos();
                }
                else if(contador==32||contador==(int)'\n')
                {
                    contador++;
                    Estado0();
                }
                else
                {
                    Estado0();
                }
                  
            }
        }
        public void Error()
        {
            mostrar = mostrar +" error\n";
            if (contador == 32 || contador == (int)'\n')
            {
                contador++;
                Estado0();
            }
            else {
                contador++;
                Estado0();
            }
        }
        public void Aceptacion()
        {
            mostrar = mostrar + caracter[contador-1]+"\n";
            if (caracter[contador]==' ')
            {
                contador++;
            }
            Estado0();
        }
    }
}
