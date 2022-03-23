<form method="post" action="" >
    <table>
        <tr>
            <td>Intitule</td>
            <td> <input type="text"name="intitule" 
                        value="<%= (leDocument!=null)?leDocument.Intitule:"" %>"> </td>
        </tr>
        <tr>
            <td>Nb de pages</td>
            <td><input type="text" name="nbPages"
                       value="<%= (leDocument!=null)?leDocument.NbPages+"":"" %>"></td>
        </tr>
        <tr>
            <td>Contexte</td>
            <td><input type="text" name="contexte"
                       value="<%= (leDocument!=null)?leDocument.Contexte:"" %>"></td>
        </tr>
        <tr>
            <td>Nom</td>
            <td><input type="text" name="nom"
                       value="<%= (leDocument!=null)?leDocument.Nom:"" %>"></td>
        </tr>
        <tr>
            <td>Prénom</td>
            <td><input type="text" name="prenom"
                       value="<%= (leDocument!=null)?leDocument.Prenom:"" %>"></td>
        </tr>
        <tr>
            <td>Soutenance</td>
            <td><input type="text" name="soutenance"
                       value="<%= (leDocument!=null)?leDocument.Soutenance:"" %>"></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" 
  <%= (leDocument!=null)? "name='modifier' value='Modifier'":"name='valider' value='Valider'" %>
                       > </td>
        </tr>
  <%= (leDocument!=null)? "<input type='hidden' name='idmemoire' value='"+leDocument.IDmemoire+"'>":"" %>
    </table>

</form>
