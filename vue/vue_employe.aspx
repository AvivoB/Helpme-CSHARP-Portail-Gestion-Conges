
<!-- #Include virtual="./header.aspx" -->


<%

    List<Conge> conges = controleur.selectWhereConge(Request.Cookies["id"].Value);

    if (Request.Form["submit_conge"] != null)
    {
        String date_debut = Request.Form["date_debut"];
        String date_fin = Request.Form["date_fin"];
        String _id = Request.Cookies["id"].Value;

        controleur.insertConge(date_debut, date_fin, _id);

        Response.Redirect("./vue_employe.aspx");

    } else {
        Debug.WriteLine("not working!");
    }
    
%>
            <div class="container-xxl flex-grow-1 container-p-y">
              <div class="row">
                <div class="col-lg-10 mb-4 order-0">
                  <div class="card">
                    <div class="d-flex align-items-end row">
                      <div class="col-sm-7">
                        <div class="card-body">
                          <h5 class="card-title text-primary">Bonjour, <%= user.Prenom %> <%= user.Nom%></h5>
                          <p class="mb-4">
                            Bienvenue sur votre espace de gestion de vos disponibilites, vous pouvez modifier votre statut via 
                            cette plateforme
                          </p>
                          <div>
                              <% if (user.IdStatut == "1") { %>
                              <div class="m-1 btn btn-sm btn-outline-success"><p>DISPONIBLE</p></div>
                              <% } else if (user.IdStatut == "2") { %>
                              <div class="m-1 btn btn-sm btn-outline-primary"><p>EN CONGES</p></div>
                              <% } else if (user.IdStatut == "3") { %>
                              <div class="m-1 btn btn-sm btn-outline-danger"><p>ARRET DE TRAVAIL</p></div>
                              <% } Debug.WriteLine(user.IdStatut);%>
                          </div>
                        </div>
                      </div>
                      <div class="col-sm-5 text-center text-sm-left">
                        <div class="card-body pb-0 px-0 px-md-4">
                          <img
                            src="../assets/img/illustrations/man-with-laptop-light.png"
                            height="140"
                            alt="View Badge User"
                            data-app-dark-img="illustrations/man-with-laptop-dark.png"
                            data-app-light-img="illustrations/man-with-laptop-light.png"
                          />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                  <!--
                <div class="col-lg-2 col-md-4 order-1">
                  <div class="row">
                    <div class="col-lg-12 col-md-12 col-6 mb-4">
                      <div class="card">
                        <div class="card-body">
                          <div class="card-title d-flex align-items-end justify-content-between">
                            <div class="avatar flex-shrink-0">
                              <img
                                src="../assets/img/icons/unicons/chart-success.png"
                                alt="chart success"
                                class="rounded"
                              />
                            </div>
                            <span class="fw-semibold d-block mb-1">Jours restants</span>
                          </div>
                          
                          <h3 class="card-title mb-2"><br/><br/>jour(s)</h3>
                        </div>
                      </div>
                    </div>

                  </div>
                    
                </div>
                  -->

                <!-- Total Revenue -->

                <!--/ Total Revenue -->
              </div>
              <div class="row">
                <!-- Mon historique -->
                <div class="col-md-6 col-lg-4 col-xl-4 order-0 mb-4">
                  <div class="card h-100">
                    <div class="card-header d-flex align-items-center justify-content-between pb-0">
                      <div class="card-title mb-0">
                        <h5 class="m-0 me-2">Mon historique</h5>
                      </div>

                    </div>
                    <div class="card-body">
                      <div class="d-flex justify-content-between align-items-center mb-3">
                        
                      </div>
                      <ul class="p-0 m-0">
                          <% foreach (Conge conge in conges) { 
                          if (conge.Approuve == "1"){ %>
                        <li class="d-flex mb-4 pb-1">
                          <div class="avatar flex-shrink-0 me-3">
                            <span class="avatar-initial rounded bg-label-primary"
                              ><i class='bx bxs-timer'></i></span>
                          </div>
                          <div class="d-flex w-100 flex-wrap align-items-center justify-content-between gap-2">
                            <div class="me-2">
                              <h6 class="mb-0"><%= conge.Days %> jour(s)</h6>
                              <small class="text-muted"><%= conge.Date_debut.Substring(0, 10) %></small>
                            </div>
                            <div class="user-progress">
                              <small class="fw-bold text-primary">Conges</small>
                            </div>
                          </div>
                        </li>
                          <% } 
                            }    
                          %>
                      </ul>
                    </div>
                  </div>
                </div>
                <!--/ Mon historique -->

                <!-- Mes demandes -->
                <div class="col-md-6 col-lg-4 col-xl-4 order-0 mb-4">
                  <div class="card h-100">
                    <div class="card-header d-flex align-items-center justify-content-between pb-0">
                      <div class="card-title mb-0">
                        <h5 class="m-0 me-2">Mes demandes</h5>
                      </div>

                    </div>
                    <div class="card-body">
                      <div class="d-flex justify-content-between align-items-center mb-3">
                        
                      </div>
                      <ul class="p-0 m-0">
                          <% foreach (Conge conge in conges) { %>
                        <li class="d-flex mb-4 pb-1">
                          <div class="avatar flex-shrink-0 me-3">
                            <span class="avatar-initial rounded bg-label-info">
                                <i class='bx bxs-message-dots'></i>
                          </div>
                          <div class="d-flex w-100 flex-wrap align-items-center justify-content-between gap-2">
                            <div class="me-2">
                              <h6 class="mb-0"><%= conge.Days %> jour(s)</h6>
                              <small class="text-muted"><%= conge.Date_debut.Substring(0, 10) %> au <%= conge.Date_fin.Substring(0, 10) %></small>
                            </div>
                            <div class="user-progress">
                                <% if (conge.Approuve == "0") { %>
                                <small class="fw-bold text-info">EN ATTENTE D'UNE REPONSE</small>
                                <% } else if (conge.Approuve == "1") { %>
                                <small class="fw-bold text-success">ACCEPTE</small>
                                <% } else if (conge.Approuve == "2") { %>
                                <small class="fw-bold text-danger">REFUSE</small>
                                <% } %>
                            </div>
                          </div>
                        </li>
                        <% } %>
                      </ul>
                    </div>
                  </div>
                </div>
                <!--/ Mes demandes -->

                <!-- Bouttons d'actions -->
                <div class="col-md-6 col-lg-4 col-xl-4 order-0 mb-4">
                    <div class="card h-100">
                        <div class="card-header d-flex align-items-center justify-content-between pb-0">
                          <div class="card-title mb-0">
                            <h5 class="m-0 me-2">Nouvelle demande de conges</h5>
                          </div>
    
                        </div>
                        <div class="card-body">
                          <div class="mt-3">
                            <div>
                                <!-- 
                                
                                    FORMS!

                                -->
                                <form action="" method="post">
                                    <input type="date" name="date_debut" class="form-control w-100" name="date-debut-conge">
                                    <div id="defaultFormControlHelp" class="form-text text-center fw-bold">
                                      au
                                    </div>
                                    <input type="date" name="date_fin" class="form-control w-100" name="date-fin-conge">
                                    <input type="submit" name="submit_conge" class="btn btn-primary mt-3 w-100" value="Faire une demande"/>
                                </form>
                              </div>
                          </div>
                    </div>
                    
                </div>
                <!--/ Boutton d'action  -->






              </div>
            </div>
            <!-- / Content -->

            <!-- Footer -->
            <footer class="content-footer footer bg-footer-theme">
              <div class="container-xxl d-flex flex-wrap justify-content-between py-2 flex-md-row flex-column">
                <div class="mb-2 mb-md-0">
                  Help'me Copyright
                  <script>
                    document.write(new Date().getFullYear());
                  </script>
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
    <script src="../assets/vendor/libs/apex-charts/apexcharts.js"></script>

    <!-- Main JS -->
    <script src="../assets/js/main.js"></script>

    <!-- Page JS -->
    <script src="../assets/js/dashboards-analytics.js"></script>

    <!-- Place this tag in your head or just before your close body tag. -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>
  </body>
</html>
