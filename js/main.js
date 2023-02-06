(function(){
'use strict';
    console.log("DOM loaded");

    //change test at interval
     const wordArray = ['oven','sofa','dish washer']

    //display section
   function showSection(mainLink, mainSection){
    document.querySelector(mainLink).addEventListener('click',function(){
        document.querySelector(mainSection).classList.toggle('d-none');
        //document.querySelector('.linkCaret').classList.toggle('fa-caret-down');
        
    },false);
   }

   showSection('#showFurnitureSection','#SmartOne-furniture-section');
   showSection('#showApplianceSection','#SmartOne-appliance-section');

})();