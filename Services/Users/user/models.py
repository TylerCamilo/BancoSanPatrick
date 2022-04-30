from django.db import models
from django.contrib.auth.models import User

#New user model.
class ExtendedUser(models.Model):
    user = models.OneToOneField(User, on_delete=models.CASCADE, 
                                null=False, 
                                blank=False, primary_key=True)
    card = models.TextField(max_length=10)
    pin = models.TextField(max_length=4)
    
    def __str__(self):
        return str(self.user.id)