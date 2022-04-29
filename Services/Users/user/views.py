#from re import U
from django.http import JsonResponse
from django.contrib.auth.models import User
from user.models import ExtendedUser
from rest_framework.views import APIView
from rest_framework_simplejwt.tokens import RefreshToken

#Crea el token
def get_tokens_for_user(user):
    refresh = RefreshToken.for_user(user)
    return str(refresh.access_token)
    

#Devueve Token y data del user
class GetTokenWiev(APIView):
    
    def post(self, request):
        card = request.data['card']
        pin = request.data['pin']
       
        result = ExtendedUser.objects.filter(card=card).filter(pin=pin).exists()
        
        if result:
            user = User.objects.get(extendeduser__card=card, extendeduser__pin=pin)
            
            if user:
                data_user = {
                        'id':user.id,
                        'email':user.email,
                        'username':user.username,
                        'token':get_tokens_for_user(user)
                    }
            return JsonResponse({'status':'200', 'data':data_user}, safe=False)
        else:
            return JsonResponse({'msg':'Error: Bad Request...','status':'400'}, safe=False)