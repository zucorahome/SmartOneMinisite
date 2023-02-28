(function(){
'use strict';
    console.log("DOM loaded");

    //change test at interval
     

     //changing text function
        const target = document.querySelector('#changeWord');
        const wordArray = ['sofa','fridge','oven'];
        window.setInterval(function(){
            const randomNumber = Math.floor(Math.random() * (3 - 0) + 0);
            target.style.opacity = '0';
            target.innerHTML = wordArray[randomNumber] + '?';
            //window.setTimeout(wordFade(),1000);
            wordFade();
            //window.setTimeout((target.style.opacity = '0'),1000);
        },2000);



        function wordFade(){
            document.querySelector('#changeWord').style.opacity = 1;
        }

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
        x.classList.add('show');
    }
   },false);

   
const windowScreesize = window.innerWidth;


})();