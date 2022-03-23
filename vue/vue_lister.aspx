<table border="1">
    <tr>
        <td>Id Mémoire</td> <td>Intitulé</td> <td>NB Pages</td>
        <td>Contexte</td> <td>Nom</td> <td>Prénom</td>
        <td> Soutenance </td> <td>Opérations</td>
    </tr>
   
    <%
    string chaine = ""; 
    foreach (Document unDocument in lesMemoires)
    {
        chaine += "<tr> <td>"+unDocument.IDmemoire+"</td><td>"+ unDocument.Intitule ; 
        chaine += "</td><td>"+ unDocument.NbPages +"</td><td>"+ unDocument.Nom +"</td>";
        chaine +="<td>"+ unDocument.Prenom +"</td> <td>"+ unDocument.Contexte +"</td>"; 
        chaine += "<td>"+ unDocument.Soutenance +"</td>"; 
    
        chaine += "<td> <a href='Default.aspx?action=sup&idmemoire="+unDocument.IDmemoire+"'>"; 
        chaine += "<img src='images/sup.png' height='40' width='40'></a>";
    
        chaine += "<a href='Default.aspx?action=edit&idmemoire="+unDocument.IDmemoire+"'>"; 
        chaine += "<img src='images/edit.png' height='40' width='40'></a>";
        
        chaine += "</td></tr>"; 
    }
    %>
    <%= chaine %>
</table>
            
        
    