

SELECT P.[parteCorpo] FROM[partiCorpo] AS P 
INNER JOIN[ambulatori] AS A ON A.[idParteCorpo] = P.[idParteCorpo] 
INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[nomeEsame]= 'RMN cranio'

