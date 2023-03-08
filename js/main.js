(function(){
'use strict';
    console.log("DOM loaded");

    //change test at interval
     

     //changing text function
        const target = document.querySelector('#changeWord');
        const wordArray = ['sofa?','fridge?','oven?'];
       //for french SOFA/FOUR/FRIGO
       
        (function displayWord(i) {
            $("#changeWord").text(wordArray[i]).fadeIn(1000, function(){
                $(this).delay(600).fadeOut(1000, function () {
                    displayWord((i + 1) % wordArray.length);
                  });
              });
          })(0);
          

    //display section
   function showSection(mainLink, mainSection){
    document.querySelector(mainLink).addEventListener('click',function(){
        document.querySelector(mainSection).classList.toggle('d-none');
        this.childNodes[1].children[0].children[0].classList.toggle('fa-caret-down');
    },false);
   }

   showSection('#showFurnitureSection','#SmartOne-furniture-section');
   showSection('#showApplianceSection','#SmartOne-appliance-section');

   //expand all link clicked

   document.querySelector('#expandAll').addEventListener('click',function(){
    let AllFAQAccordions = document.querySelectorAll('#FAQAccordion .accordion-collapse');
    
    for(const x of AllFAQAccordions){
        x.classList.toggle('show');
    }
        if(window.location.href.indexOf('french') > 0){
            if(this.innerHTML == 'Ouvrir tout'){
                this.innerHTML = 'Réduire tout';
            }else{
                this.innerHTML = 'Ouvrir tout';
            }
        }else{
            if(this.innerHTML == 'Expand all'){
                this.innerHTML = 'Collapse all';
            }else{
                this.innerHTML = 'Expand all';
            }
        }
   },false);

   
const windowScreesize = window.innerWidth;


})();