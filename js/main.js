(function(){
'use strict';
    console.log("DOM loaded");

    //change test at interval
     

     //changing text function
        const target = document.querySelector('#changeWord');
        const wordArray = ['sofa','fridge','oven'];
        window.setInterval(function(){
            const randomNumber = Math.floor(Math.random() * (3 - 0) + 0);
            target.innerHTML = wordArray[randomNumber] + '?';
        },1500);

        

    //display section
   function showSection(mainLink, mainSection){
    document.querySelector(mainLink).addEventListener('click',function(){
        document.querySelector(mainSection).classList.toggle('d-none');
        this.children[0].classList.toggle('fa-caret-down');
    },false);
   }

   showSection('#showFurnitureSection','#SmartOne-furniture-section');
   showSection('#showApplianceSection','#SmartOne-appliance-section');

   //expand all link clicked

   document.querySelector('#expandAll').addEventListener('click',function(){
    let AllFAQAccordions = document.querySelectorAll('#FAQAccordion .accordion-collapse');
    for(const x of AllFAQAccordions){
        x.classList.add('show');
    }
   },false);

})();