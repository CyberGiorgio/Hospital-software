SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] FROM[ambulatori] AS A INNER JOIN[partiCorpo] AS P ON A.[idParteCorpo] = P.[idParteCorpo] INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame] WHERE E.[nomeEsame]
LIKE '%rmn%' OR E.[codiceMinisteriale] LIKE '%rmn%' 
OR  E.[codiceInterno] LIKE '%rmn%' OR  E.[descrizione] LIKE '%rmn%';