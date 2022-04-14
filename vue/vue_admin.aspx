<!-- #Include virtual="./header.aspx" --> 

<%

    List<User> users = controleur.selectAllUsers();

    List<Conge> conges = controleur.selectAllConges();

    if (Request.Form["approuver"] != null)
    {
        String id_conge = Request.Form["id_conge"];
        controleur.updateConge(id_conge, "1");

        Response.Redirect("./vue_admin.aspx");

    } else if (Request.Form["refuser"] != null) {
        String id_conge = Request.Form["id_conge"];
        controleur.updateConge(id_conge, "2");

        Response.Redirect("./vue_admin.aspx");
    }
    
%>

<div class="menu-inner-shadow"></div>
          <!-- Content wrapper -->
          <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"></span> Gestion des conges de Help'me</h4>

              <!-- Liste des employés -->
              <div class="card">
                <h5 class="card-header">Liste des employes</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table">
                    <thead>
                      <tr>
                        <th>Nom et prenom</th>
                        <th>E-mail</th>
                        <!--<th>Service</th>-->
                        <th>Status</th>
                        <!--<th>Actions</th>-->
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                        <% foreach (User u in users) { %>
                      <tr>
                        <td><i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%= u.Prenom %> <%= u.Nom %></strong></td>
                        <td><%= u.Email %></td>
                        <!--<td>Chauffeur</td>-->
                          <% if (u.IdStatut == "1") { %>
                        <td><span class="badge bg-label-success me-1"><%= u.Statut %></span></td>
                          <% } else if (u.IdStatut == "2") { %>
                        <td><span class="badge bg-label-danger me-1"><%= u.Statut %></span></td>
                          <% } %>
                        <!--<td>
                          <div class="dropdown">
                            <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                              <i class="bx bx-dots-vertical-rounded"></i>
                            </button>
                            <div class="dropdown-menu">
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-edit-alt me-1"></i> Edit</a
                              >
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-trash me-1"></i> Delete</a
                              >
                            </div>
                          </div>
                        </td>-->
                       </tr>
                        <% } %>

                    </tbody>
                  </table>
                </div>
              </div>
              <!--/ Liste des employés -->

              <hr class="my-5" />
              <!-- Liste des demandes -->
              <div class="card">
                <h5 class="card-header">Liste des demandes</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table">
                    <thead>
                      <tr>
                        <th>Nom et prenom</th>
                        <th>Jours de conges souhaite</th>
                        <th>Date de conge</th>
                        <th>Actions</th>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                       <% foreach (Conge conge in conges) { %>
                        <% if (conge.Approuve == "0") { %>
                      <tr>
                        <td><i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%= conge.Prenom %> <%= conge.Nom %></strong></td>
                        <td><%= conge.Days %> jour(s)</td>
                        <td><%= conge.Date_debut.Substring(0, 10) %> au <%= conge.Date_fin.Substring(0, 10) %></td>
                        <td>
                          <div class="dropdown">
                            <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                              <i class="bx bx-dots-vertical-rounded"></i>
                            </button>
                            <div class="dropdown-menu">
                                <form method="post">
                                    <i class='bx bxs-check-circle' style="display: inline;"></i> 
                              <input style="display: inline;" type="submit" value="Approuver" name="approuver" class="dropdown-item" href="javascript:void(0);"/
                                >
                                    <input hidden type="text" name="id_conge" value="<%=conge.IdConge%>"/>
                                    </form>
                                <form method="post">
                                    <i class='bx bx-block' style="display: inline;"></i> 
                              <input style="display: inline;" type="submit" value="Refuser" name="refuser" class="dropdown-item" href="javascript:void(0);"
                                />
                                    <input hidden type="text" name="id_conge" value="<%=conge.IdConge%>"/>
                              </form>
                            </div>
                          </div>
                        </td>
                       </tr>
                        <% }
                        }%>
                      
                    </tbody>
                  </table>
                </div>
              </div>
              <!--/ Liste des demandes -->

            </div>
            <!-- / Content -->

            <!-- Footer -->
            <footer class="content-footer footer bg-footer-theme">
              <div class="container-xxl d-flex flex-wrap justify-content-between py-2 flex-md-row flex-column">
                <div class="mb-2 mb-md-0">
                  Copyright
                  <script>
                    document.write(new Date().getFullYear());
                  </script>
                  
                </div>
                <div>
                 
                </div>
              </div>
            </footer>
            <!-- / Footer -->

            <div class="content-backdrop fade"></div>
          </div>
          <!-- Content wrapper -->
        </div>
        <!-- / Layout page -->
      </div>

      <!-- Overlay -->
      <div class="layout-overlay layout-menu-toggle"></div>
    </div>
    <!-- / Layout wrapper -->

    <!-- Core JS -->
    <!-- build:js assets/vendor/js/core.js -->
    <script src="../assets/vendor/libs/jquery/jquery.js"></script>
    <script src="../assets/vendor/libs/popper/popper.js"></script>
    <script src="../assets/vendor/js/bootstrap.js"></script>
    <script src="../assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"></script>

    <script src="../assets/vendor/js/menu.js"></script>
    <!-- endbuild -->

    <!-- Vendors JS -->

    <!-- Main JS -->
    <script src="../assets/js/main.js"></script>

    <!-- Page JS -->

    <!-- Place this tag in your head or just before your close body tag. -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>
  </body>
</html>
