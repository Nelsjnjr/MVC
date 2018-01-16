
// change the client id here
var instagramClientid = 'abf83dbafb9f4dc1a5c5307208a9f35e';



// these variable is used for instagram, if we dont need instagram, delete these
var instagramHtmlContent = '';
var instagramMaxTagId = '';
var instagramImageIdArray = new Array();






// add google map

if(typeof(showmap)==='number'){
 
  var map;
  function initialize() {
      
    var myLatlng = new google.maps.LatLng(25.075839, 55.140649);
    var mapOptions = {
      zoom: 16,
      center: myLatlng,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('gmapContainer'),
        mapOptions);
    
      var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Pier7'
    });
  }
  
  google.maps.event.addDomListener(window, 'load', initialize);
}


(function($){
  
    var leftImagePath = ''
    
    $('document').ready(function(){
      
      if($('#leftImage').index() >=0 ){
              
        leftImagePath = $('#leftImage').attr('src');
              
      }
      
      
      if( $(window).width() <= 719 ){        
        
        if($('#leftImage').index() >=0 ){
              
          $('#leftImage').attr({src: $('#leftImage').attr('rel') });
                        
        }    
        
      }
        
        
        // fade in / fade out homepage images on mouse over
        $('.imageLinkCol').hover(function(){        
            
            $(this).find('.colouredImage').animate({opacity:1}, 300);
            
        }, function(){

            $(this).find('.colouredImage').stop().animate({opacity:0}, 300);
            
        });
        
         $('.inthepress-item').hover(function(){
          
            if( $(window).width() > 980 ){
          
              $(this).find('.pressinfo').slideDown();
              
            }
            
          }, function(){
            
            if( $(window).width() > 980 ){
             
              $(this).find('.pressinfo').slideUp();
              
            }
          
          });
         
         
         
         /********************************************************************/
         /*************************** Responsive stuff ***********************/
         /********************************************************************/
         
         // show / hide the top menu on click if the scrren width is less than 979
         $('.topmenuContainer').click(function(){
          
            if( $(window).width() < 719 ){
             
              $('.topmenuList').toggle(); 
              
            }
          
          });
         
         
         // when the window is resized
         $(window).resize(function(){
          
          if($(window).width() > 719){
            
            $('.topmenuList').show();
            $('.submenu ul li.active').height('auto');
            $('.restaurantContent').css('top', '');
            
            if($('#leftImage').index() >=0 ){            
              
              $('#leftImage').attr({src:leftImagePath });                                    
            }
            
            
          }else{
            
            $('.topmenuList').hide();
            positionRestaurantContent();
            
            
            if($('#leftImage').index() >=0 ){            
              
              $('#leftImage').attr({src: $('#leftImage').attr('rel') });                                    
            }
            
            
            
          }
          
    
         });
         
         positionRestaurantContent();
         
         
         /********************************************************************/
         /*********************** end of Responsive stuff ********************/
         /********************************************************************/
         
         
         
         
         
         
         
         // the custom scroller
         if( jQuery().mCustomScrollbar){
         
          $(".rightContainer").mCustomScrollbar({
                autoHideScrollbar:true,
                theme:"dark-thin"
          });
          
          $(".restaurantContent .left p").mCustomScrollbar({
                autoHideScrollbar:true,
                theme:"dark-thin"
          }); 
          
         }
         
         
         
         /********************************************************************/
         /*********************** show / hide elements in gallery ************/
         /********************************************************************/
         
         $('.gallery-submenu li a').click(function(){
          
            
            if( $(this).attr('rel').length > 1 ){
            
              $('.gallery-submenu li.active').attr({'class':''});
                 
              $(this).parent('.gallery-submenu li').attr({'class':'active'});
              
              $('.galleryContainer').hide();
              
              $('#'+$(this).attr('rel')).show();
              
              $(".rightContainer").mCustomScrollbar("update");
            
            }
            
            return false;
          
         });
         
         
         var curPopupImage = '';
         
         
         function loadPopupImage(largeImage){
          
            var srcPath = 'assets/img/gallery/';            
            var img = document.createElement('img');
            
            img.onload = function(){
                            
              $('.popupContainer .popup').animate({width:this.width, height:this.height, marginLeft:-(this.width/2), marginTop:-(this.height/2)}, 200);
              
              
            }
            
            img.src=srcPath+largeImage;
            
            $('.popupImg').html(img);
          
         }
         
         
         
         
         $('#corporate .gallery-item').click(function(){
          
            curPopupImage = $(this).index();
          
            $('.popupContainer').show();
            var largeImage = $(this).attr('rel');
            
            loadPopupImage(largeImage);
            
            //console.log(curPopupImage);
            
          });
         
         
         
         
          $('.popupContainer .prev').click(function(){
            
            if( curPopupImage - 1 < 0){
              
              curPopupImage = $('#corporate .gallery-item').length;
              
            }
            
            curPopupImage--;
          
            var largeImage = $('#corporate .gallery-item').eq(curPopupImage).attr('rel');
            
            loadPopupImage(largeImage);
            
            //console.log(curPopupImage);
          
          })
          
          
          
          $('.popupContainer .next').click(function(){
          
             if( curPopupImage + 1 >= $('#corporate .gallery-item').length ){
              
              curPopupImage = -1;
              
            }
            
            curPopupImage++;
          
            var largeImage = $('#corporate .gallery-item').eq(curPopupImage).attr('rel');
            
            loadPopupImage(largeImage);
            
            //console.log(curPopupImage);
          
          }) 
         
         
         
         $('.popupContainer .closeButton').click(function(){
          
            $('.popupContainer').hide();
          
          })
         
         
                  
         /********************************************************************/
         /************* end of show / hide elements in gallery ***************/
         /********************************************************************/
         
         
        /**************************************************************************************/
        /************************************ the instagram stuffs ******************************/
        /**************************************************************************************/
        
        // remove this if we are not using instagram
        
        if(typeof showInstagramGallery== 'number' && showInstagramGallery == 1){
          
          var instagramUrl = 'https://api.instagram.com/v1/tags/pier7dubai/media/recent?callback=?';
         
          
            
   
          function dataLoaded(instagramData){
            
            instagramMaxTagId = instagramData.pagination.next_max_id;
            
            if(instagramData.meta.code == 200){
              
              //console.log(instagramData.data);
              
              
              for( imgObj in instagramData.data){
                
                //console.log(imgObj);
                
                if( $.inArray(instagramData.data[imgObj].id, instagramImageIdArray) > -1 ){
                
                  $('#instagramLoadMore').hide();
                  return;  
                    
                }
                
                
                instagramImageIdArray.push(instagramData.data[imgObj].id);
                
                instagramHtmlContent  += "<div class='gallery-item'> <a href='"+ instagramData.data[imgObj].link +"' target='_blank'> <img src='"+ instagramData.data[imgObj].images.thumbnail.url +"' /> </a> </div>"
               
                
              }
              
              //console.log( instagramImageIdArray.join(' , ') );
              
              var loadMoreBtn = "<div id='instagramLoadMore'><a href='#' style='font-size:1em; margin-top:20px; display:block;'> More >></a></div>"
              
              $('#instagram').html('');
              
              $('#instagram').html(instagramHtmlContent);
              $('#instagram').append(loadMoreBtn);
              
              
              $('#instagramLoadMore').click(function(){
          
                loadMoreinstagramImages();
                return false;
                
              });
              
              // update the custom scroller
              if( jQuery().mCustomScrollbar){
              
                $(".rightContainer").mCustomScrollbar("update");
              }
               
            }else{
              
              alert('an error occured');
              
            }
            
          }
          
          $.getJSON(instagramUrl, {client_id:instagramClientid}, dataLoaded);
          
          
        }
        
        
        
        
        
        
        function loadMoreinstagramImages(){
          
            $.getJSON(instagramUrl, {client_id:instagramClientid, max_tag_id:instagramMaxTagId}, dataLoaded);
            
          
        }
        
        // remove till here if we dont want instagram
        
        
        /**************************************************************************************/
        /************************************ end of instagram stuffs *************************/
        /**************************************************************************************/
      
      
      
        /**************************************************************************************/
        /************************************ reservation form ******************************/
        /**************************************************************************************/
        
        $('#reservationForm input[type=text]').focus(function(){
          
          $('input.active').attr({class:''});
          
          $(this).attr({class:'active'});
          
          if( $(this).val() == $(this).attr('rel') ){
          
            $(this).attr({value:''});
            
          }
          
        });
        
        
        $('#reservationForm input[type=text]').blur(function(){
          
          var val = $(this).attr('rel');
          if( $(this).val().length <1 ){
              
            $(this).attr({value: val});
            
          }
          
          
        });
        
        
     //   $('#userdate').datepicker();
        /**************************************************************************************/
        /************************************ end of reservation form *************************/
        /**************************************************************************************/
        
        
    });
        
    
    // positions the content in restaurant page
    function positionRestaurantContent(){
      
      if( typeof restaurantPage ==  'number'){
        
        if($(window).width() <= 719){
          
          var totalDistanceToBeMoved = ($('.submenu ul li.active').offset().top - $('.rightContainer').offset().top) + 20;      
          // set active li height = height of the content container
          $('.submenu ul li.active').height($('.restaurantContent').outerHeight(true));
             
          // move the container to position
          $('.restaurantContent').css('top', totalDistanceToBeMoved+'px');
          
        }else{
        
          $('.submenu ul li.active').height('auto');
          
        }  
      }
      
    }
    
    
})(jQuery)