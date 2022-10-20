using System;
using Microsoft.EntityFrameworkCore;

namespace Model;
public class User
{
    public int id {get; set;}
    public string nome {get; set;}
    public string login {get; set;}
    public string senha {get; set;}

    public int save(){
        using(var context = new Context()){
            var user = new User(){
                id = this.id,
                nome = this.nome,
                login = this.login,
                senha = this.senha
            };
            context.User.Add(user);
            context.SaveChanges();
        }
        return id;
    }

    public static object findID(string login){
        using(var context = new Context()){
            var user = context.User.FirstOrDefault(u => u.login == login);
            return new
            {
                id = user.id,
                nome = user.nome,
                login = user.login,
                senha = user.senha
            };
        }
    }

    public static object findByID(int id){
        using(var context = new Context()){
            var user = context.User.FirstOrDefault(u => u.id == id);
            return new
            {
                id = user.id,
                nome = user.nome,
                login = user.login,
                senha = user.senha
            };
        }
    }

    public static void update(User user, string login){
        using(var context = new Context()){
            var userVar = context.User.FirstOrDefault(u => u.login == login);
            
            if(user.senha != null){
                userVar.senha = user.senha;
            }
            if(user.login != null)
            {
                userVar.login = user.login;
            }
            context.SaveChanges();
        }
    }

    public static string deleta(int id){
        using(var context = new Context())
        {
            var user = context.User.FirstOrDefault(u => u.id == id);
            context.Remove(user);  
            context.SaveChanges();
            return "foi removido!";
        }
    }
}
