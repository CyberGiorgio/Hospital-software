SELECT E.[idEsame], E.[nomeEsame], E.[codiceMinisteriale], E.[codiceInterno], E.[descrizione] 
                    FROM[ambulatori] AS A 
                    INNER JOIN[ambulatoriPartiCorpo] AS AP ON AP.[idAmbulatorio] = A.[idAmbulatorio] 
                    INNER JOIN[partiCorpo] AS P ON AP.[idParteCorpo] = P.[idParteCorpo] 
                    INNER JOIN[esami] AS E ON P.[idEsame] = E.[idEsame]
                    WHERE AP.idAmbulatorio = 0 AND AP.idParteCorpo = 1;