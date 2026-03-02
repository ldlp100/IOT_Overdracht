// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.


//Waternet SERVER API
export const environment = {
 production: false,
 IoTExServiceAPIUri: 'https://iot-api-p-waternet-app-gvavfbafewgpbwdx.westeurope-01.azurewebsites.net',
 IoTExTitleApplication: 'Waternet IoT Portal',
 mapSubscriptionKey:"CiooIGCZ9MoKsPlut9oOF83jwizf2EZqRCigU36iOLqPEXr4WTtBJQQJ99AKAC5RqLJ06SyIAAAgAZMP1T1j",
 IoTExAuthorization: {
   clientId: 'b1ece2c9-224b-48ca-bad2-cf9c15fac68e',
   scope: 'api://b1ece2c9-224b-48ca-bad2-cf9c15fac68e/IoTEx.User',
   redirectUri: 'https://iotportalspawaternetpsa.z6.web.core.windows.net/',
   postLogoutRedirectUri: 'https://iotportalspawaternetpsa.z6.web.core.windows.net/',
   authority: "https://login.microsoftonline.com/dc176db0-cbcb-4c49-84e9-efe31a545c55/",
   navigateToLoginRequestUrl: true
 }
};

//Waternet LOCAL SERVER API
// export const environment = {
//  production: false,
//  IoTExServiceAPIUri: 'https://iot-api-p-waternet-app-gvavfbafewgpbwdx.westeurope-01.azurewebsites.net',
//  //IoTExServiceAPIUri: 'https://localhost:7082',
//  IoTExTitleApplication: 'Waternet IoT Portal',
//  mapSubscriptionKey:"CiooIGCZ9MoKsPlut9oOF83jwizf2EZqRCigU36iOLqPEXr4WTtBJQQJ99AKAC5RqLJ06SyIAAAgAZMP1T1j",
//  IoTExAuthorization: {
//    clientId: 'b1ece2c9-224b-48ca-bad2-cf9c15fac68e',
//    scope: 'api://b1ece2c9-224b-48ca-bad2-cf9c15fac68e/IoTEx.User',
//    redirectUri: 'http://localhost:4200/',
//    postLogoutRedirectUri: 'http://localhost:4200/',
//    authority: "https://login.microsoftonline.com/dc176db0-cbcb-4c49-84e9-efe31a545c55/",
//    navigateToLoginRequestUrl: true
//  }
// };

//Waternet LOCAL LOCAL API
// export const environment = {
//  production: false,
//  //IoTExServiceAPIUri: 'https://iot-api-p-waternet-app-gvavfbafewgpbwdx.westeurope-01.azurewebsites.net',
//  IoTExServiceAPIUri: 'https://localhost:7082',
//  IoTExTitleApplication: 'Waternet IoT Portal',
//  mapSubscriptionKey:"CiooIGCZ9MoKsPlut9oOF83jwizf2EZqRCigU36iOLqPEXr4WTtBJQQJ99AKAC5RqLJ06SyIAAAgAZMP1T1j",
//  IoTExAuthorization: {
//    clientId: 'b1ece2c9-224b-48ca-bad2-cf9c15fac68e',
//    scope: 'api://b1ece2c9-224b-48ca-bad2-cf9c15fac68e/IoTEx.User',
//    //redirectUri: 'https://iotportalspawaternetpsa.z6.web.core.windows.net/',
//    redirectUri: 'http://localhost:4200/',
//    //postLogoutRedirectUri: 'https://iotportalspawaternetpsa.z6.web.core.windows.net/',
//    postLogoutRedirectUri: 'http://localhost:4200/',
//    authority: "https://login.microsoftonline.com/dc176db0-cbcb-4c49-84e9-efe31a545c55/",
//    navigateToLoginRequestUrl: true
//  }
// };


