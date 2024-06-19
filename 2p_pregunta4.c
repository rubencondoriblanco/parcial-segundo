// Estudiante ruben condori blanco
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX  100
// Estructura para almacenar tripletes
typedef struct {
	int row;
	int col;
	int value;
} Sparse;

// Funcion para mostrar matrices
void mostrar_matriz(int matriz[101][101],int M)
{
	int i, j;
	for (i = 0; i < M; i++) 
	{
	  
	   for (j = 0; j < M; j++) 
	   {
		printf(" %d", matriz[i][j]);
	   }
		printf("\n");
	}
	printf("\n");
}
void mostrar_matriz_sparse(Sparse spmatriz[])
{
	int i, j;
	
	for( i=0 ; i <= spmatriz[0].value ; i++)
	{
	    printf("f %d \t c %d \t va %d \n",spmatriz[i].row, spmatriz[i].col, spmatriz[i].value);	

    }
	
	
}
void rellenar_matriz(int matriz[101][101], int M)
{
   int i, j;
   for (i = 0; i < M; i++)
   {
      for (j = 0; j < M; j++) 
      {
	    matriz[i][j] = rand() % 10;
      }
   }
}

// Funcion para multiplicar dos matrices dispersas
void sparseMatrixMultiply(Sparse A[],Sparse B[],Sparse C[],int *sizeC)
{
	*sizeC = 0;
	int sizA = A[0].value;
	int sizB = B[0].value;
	int i, j, k ;

	for(i = 1 ; i < sizA ; i++)
	{
		for( j = 1 ; j < sizB ; j++)
		{
			if(A[i].col == B[j].row)
			{
				int r = A[i].row;		
				int c = B[j].col;
				int value = A[i].value * B[j].value ;
				// verificamos si ya existe este elemento en el resultado
				int found = 0;
				for( k= 0; k < *sizeC; k++)
				{
					if(C[k].row == r && C[k].col == c)
					{
						C[k].value += value;
						found = 1;
						break;
					}
					
				}
				if(!found)
				{
				    C[*sizeC].row = r;
					C[*sizeC].col = c;
					C[*sizeC].value = value;
				    (*sizeC) ++;
				}
			}
		}
	}
}
void main() 
{
    // Declaracion de variables
    int matriz_a[101][101], matriz_b[101][101];
    
    int n = 30;
    
    int sizeA = 100;
	int sizeB = 100;
    Sparse A[MAX];
	Sparse B[MAX]; 
    Sparse C[MAX];

    srand(time(NULL)); // semilla para generar números aleatorios
    double tinicial, tfinal;
    
    // Llenar las matrices A y B 
	rellenar_matriz(matriz_a,n);
	rellenar_matriz(matriz_b,n);

	printf("\nMatriz A:\n");
	mostrar_matriz(matriz_a,n);

	printf("\nMatriz B:\n");
	mostrar_matriz(matriz_b,n);
	
    // Llenar las matrices A 
    int i, j;
   	int k = 1;
	for( i=0; i<n ; i++ )
	{
	    for( j=0; j<n ; j++ )
	    {
		   if(matriz_a[i][j] != 0)
	       {
		       A[k].row = i;
		       A[k].col = j;
		       A[k].value = matriz_a[i][j] ;
		       k++;
		   }
	    }
    }
	A[0].row=n;
	A[0].col=n;
	A[0].value=k-1;
	
	
	 // Llenar las matrices B 
 
    k = 1;
	for( i=0; i<n ; i++ )
	{
	    for( j=0; j<n ; j++ )
	    {
		   if(matriz_b[i][j] != 0)
	       {
		       B[k].row = i;
		       B[k].col = j;
		       B[k].value = matriz_b[i][j] ;
		       k++;
		   }
	    }
    }
	B[0].row=n;
	B[0].col=n;
	B[0].value=k-1;
 
	
    printf("\nMatriz Sparse A:\n");
    mostrar_matriz_sparse(A);
    
    printf("\nMatriz Sparse B:\n");
    mostrar_matriz_sparse(B);
    
    int sizeC;
    sparseMatrixMultiply( A,B,C, &sizeC);
    printf("\nMatriz Sparse C:\n");
    	
	for( i = 1; i < sizeC ; i++)
	{
		printf("\t C[%d][%d] = %d \n",C[i].row,C[i].col,C[i].value);
	}

	
	// Imprimir tiempo de ejecución
	printf("\n-------------------\n");


}
