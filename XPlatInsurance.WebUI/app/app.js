(function() {

  angular.module("xplat", ["ngRoute", "ngResource"])
    .config(Config)
    .factory("ClaimsFactory", ["$resource", ClaimsFactory])
    .controller("claimsList", ["ClaimsFactory", ClaimsListController])
    .controller("claimDetails", ["ClaimsFactory", "$routeParams", ClaimDetailsController]);
    

  function ClaimsListController(ClaimsFactory) {

    var vm = this;
    ClaimsFactory.query(function(data) {
      vm.claims = data;
    });

  }

  function ClaimDetailsController(ClaimsFactory, $routeParams) {

    var vm = this;
    ClaimsFactory.get({id: $routeParams.id}, function(data) {
      vm.thisClaim = data;
    });

    vm.save = function() {
      console.log(vm.thisClaim);
      console.log("Saving");
      vm.thisClaim.$update({id: vm.thisClaim.ClaimID});
    }

  }

  function ClaimsFactory($resource) {

    return $resource("/api/Claims/:id", null, {
      update: {
        method: 'PUT' // this method issues a PUT request
      }
    });

  }

  function Config($routeProvider) {

    $routeProvider.when("/details/:id", {
        templateUrl: "claimDetails.html",
        controller: "claimDetails",
        controllerAs: "vm"
    }).when("/editclaim/:id", {
      templateUrl: "editClaim.html",
      controller: "claimDetails",
      controllerAs: "vm"
    }).otherwise({
        templateUrl: "claimslist.html",
        controller: "claimsList",
        controllerAs: "vm"
      });

  }

})();