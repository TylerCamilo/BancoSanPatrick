from django.urls import path
from rest_framework_simplejwt import views as jwt_views
from .views import GetTokenWiev

urlpatterns = [
    #Genera token
    path('v1/login/', GetTokenWiev.as_view()),
]
