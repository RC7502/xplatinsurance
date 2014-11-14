(function() {

  angular.module("xplat", ["ngRoute", "ngResource"])
    .config(Config)
    .factory("Claims", ["$resource", ClaimsFactory])
    .controller("claimsList", ["Claims", ClaimsListController])
    .controller("claimDetails", ["Claims", "$routeParams", ClaimDetailsController]);
    

  function ClaimsListController(Claims) {

    var vm = this;
    Claims.query(function(data) {
      vm.claims = data;
    });

  }

  function ClaimDetailsController(Claims, $routeParams) {

    var vm = this;
    Claims.get({id: $routeParams.id}, function(data) {
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