﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public class BoardAppClass
    {
        static Dictionary<int, Person> people = OurdefaultAccount.ourDefaultPerson();

        public void run()
        {

            CartManager toDoCart = new Todokart("İngilizce", "İngilizce dersine çalışmalısın", people[1]);
            CartManager inProgressCart = new inProgress("Web development", "Web deveelepment alanında gelişmelisin", people[1]);
            CartManager DoneCart = new Done("Java", "Java alanında da gelişmelisin", people[1]);

            bool status = true;
            while (status)
            {
                Console.WriteLine("Lütfen yapacağınız işlemi seçiniz: \n" + "1-Kart Ekleme\n" + "2-Kart Çıkarma\n" + "3-Kart Güncelle\n" + "4-Kart taşı\n" + "5-Board listeleme\n" + "6-Kişileri Görüntüle\n" + "0-Çıkış");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        addCart();
                        break;
                    case 2:
                        deleteCart();
                        break;
                    case 3:
                        updateCart();
                        break;
                    case 4:
                        reLocationToCart();
                        break;
                    case 5:
                        listToBoard();
                        break;
                    case 6:
                        showAllPerson();
                        break;
                    case 0:
                        status = false;
                        break;

                }
            }
        }


        public void addCart()
        {
            Console.Write("Lütfen kart başlığını giriniz: "); string title = Console.ReadLine();
            Console.Write("Lütfen kart içeriğinini giriniz: "); string contents = Console.ReadLine();
            showAllPerson();
            Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); int id = int.Parse(Console.ReadLine());

            // Girilen ıd'nin kesin bir şekilde doğru girilmesi
            while (!people.Keys.Contains(id))
            {
                Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); id = int.Parse(Console.ReadLine());
            }
            Person selectedPerson = people[id];
            Console.WriteLine("Lütfen ekleyeceğiniz kartın hangi kolona ekleneceğini giriniz \n(1)-ToDo-(L)\n(2)-InProgress-(M)\n(3)-Done-(S)");
            int choose = int.Parse(Console.ReadLine());



            // Kartın hangi kolona girilmesi gerektiği
            if (choose == 1)
            {
                Console.WriteLine("ToDo Listesine Kart Eklendi..");
                CartManager newToDoCart = new Todokart(title, contents, selectedPerson);
            }
            else if (choose == 2)
            {
                Console.WriteLine("InProgress Listesine Kart Eklendi..");
                CartManager newInProgressCart = new inProgress(title, contents, selectedPerson);
            }
            else if (choose == 3)
            {
                Console.WriteLine("Done Listesine Kart Eklendi..");
                CartManager newDoneCart = new Done(title, contents, selectedPerson);
            }

        }


        public void deleteCart()
        {
            Console.WriteLine("Hangi bölümdeki kartı sileceksiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done");
            int choose = int.Parse(Console.ReadLine());
            Console.WriteLine("Konu başlığını giriniz: "); string title = Console.ReadLine();//Başlık kullanıcıdan alınır

            // Seçilen ToDo  İSE
            if (choose == 1)
            {
                for (int i = 0; i < Todokart.Carts.Count; i++)
                {
                    if (Todokart.Carts[i].Title == title)
                    {
                        Todokart.Carts.Remove(Todokart.Carts[i]);
                    }
                    else if (i == Todokart.Carts.Count - 1)// Son elemana geldiği halde bulunmamışsa demek öyle bir kart yoktur
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            //Seçilen InProgress ise
            else if (choose == 2)
            {
                for (int i = 0; i < inProgress.Carts.Count; i++)
                {
                    if (inProgress.Carts[i].Title == title)
                    {
                        inProgress.Carts.Remove(inProgress.Carts[i]);
                    }
                    else if (i == inProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            // Seçilen Done ise
            else if (choose == 3)
            {
                for (int i = 0; i < Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == title)
                    {
                        Done.Carts.Remove(Done.Carts[i]);
                    }
                    else if (i == Done.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;

                    }

                }

            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir işlem giriniz..");
            }
        }



        public void updateCart()
        {
            //Bu kısımda yeni veriler alınır
            Console.Write("Lütfen kart başlığını giriniz: "); String newTitle = Console.ReadLine();
            Console.Write("Lütfen kart içeriğinini giriniz: "); String newContents = Console.ReadLine();
            showAllPerson();
            Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); int id = int.Parse(Console.ReadLine());
            while (!people.Keys.Contains(id))
            {
                Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); id = int.Parse(Console.ReadLine());
            }
            Person newSelectedPerson = people[id];
            Console.WriteLine("Lütfen güncellemek istediğiniz Kartın hanngi bölümde olduğunu giriniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done");
            int choose = int.Parse(Console.ReadLine());



            if (choose == 1)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < Todokart.Carts.Count; i++)
                {
                    if (Todokart.Carts[i].Title == oldTitle)
                    {
                        Todokart.Carts[i].Title = newTitle;
                        Todokart.Carts[i].Contents = newContents;
                        Todokart.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == Todokart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }

            }



            else if (choose == 2)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < inProgress.Carts.Count; i++)
                {
                    if (inProgress.Carts[i].Title == oldTitle)
                    {
                        inProgress.Carts[i].Title = newTitle;
                        inProgress.Carts[i].Contents = newContents;
                        inProgress.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == inProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }

            else if (choose == 3)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == oldTitle)
                    {
                        Done.Carts[i].Title = newTitle;
                        Done.Carts[i].Contents = newContents;
                        Done.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == Done.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }

            else
            {
                Console.WriteLine("Lütfen geçerli bir seçim yapınız..");
            }

        }

        public void reLocationToCart()
        {
            Console.WriteLine("Lütfen hangi kolondaki kartı seçmek istediğinizi belirtiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done"); int choose = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kartı hangi kolona taşımak istediğinizi belirtiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done"); int newLocationChoose = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kart başlığını giriniz: "); string title = Console.ReadLine();


            //------Buradakilerin aynısı
            //1.Kolondaki veri saklanacaksa
            if (choose == 1)
            {


                for (int i = 0; i < Todokart.Carts.Count; i++)
                {
                    if (Todokart.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)//Aynı kolona ekleniyorsa otomotik olarak döngüden çıkar
                            break;
                        else if (newLocationChoose == 2)// 2.kolona eklenecekse;
                        {
                            //Alınan kolonaki kart bilgileri yeni kart olarak eklenecek olan kolona eklenir..
                            inProgress newCart = new inProgress(Todokart.Carts[i].Title, Todokart.Carts[i].Contents, Todokart.Carts[i].AppointedPerson);
                            //Ve mevcut var olduğu kolondan silinir
                            Todokart.Carts.Remove(Todokart.Carts[i]);
                            break;
                        }
                        else if (newLocationChoose == 3)
                        {
                            Done newCart = new Done(Todokart.Carts[i].Title, Todokart.Carts[i].Contents, Todokart.Carts[i].AppointedPerson);
                            Todokart.Carts.Remove(Todokart.Carts[i]);
                            break;
                        }

                    }
                    else if (i == Todokart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }




            //------Buradakilerin aynısı
            else if (choose == 2)
            {
                for (int i = 0; i < inProgress.Carts.Count; i++)
                {
                    if (inProgress.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)
                        {
                            Todokart newCart = new Todokart(inProgress.Carts[i].Title, inProgress.Carts[i].Contents, inProgress.Carts[i].AppointedPerson);
                            inProgress.Carts.Remove(inProgress.Carts[i]);
                            break;
                        }

                        else if (newLocationChoose == 2)
                            break;
                        else if (newLocationChoose == 3)
                        {
                            Done newCart = new Done(inProgress.Carts[i].Title, inProgress.Carts[i].Contents, inProgress.Carts[i].AppointedPerson);
                            inProgress.Carts.Remove(inProgress.Carts[i]);
                            break;
                        }

                    }
                    else if (i == inProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }


            if (choose == 3)
            {
                for (int i = 0; i < Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)
                        {
                            Todokart newCart = new Todokart(Done.Carts[i].Title, Done.Carts[i].Contents, Done.Carts[i].AppointedPerson);
                            Done.Carts.Remove(Done.Carts[i]);
                            break;
                        }
                        else if (newLocationChoose == 2)
                        {
                            inProgress newCart = new inProgress(Done.Carts[i].Title, Done.Carts[i].Contents, Done.Carts[i].AppointedPerson);
                            Done.Carts.Remove(Done.Carts[i]);
                            break;
                        }
                        else if (newLocationChoose == 3)
                            break;


                    }
                    else if (i == Todokart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            Console.WriteLine("Kart taşıma işlemi tamamlandı..");
        }


        public void listToBoard()
        {
            Console.WriteLine("**********************ToDo Listesi**********************");
            Todokart.listToCarts();
            Console.WriteLine("**********************InProgress Listesi*****************");
            inProgress.listToCarts();
            Console.WriteLine("**********************Done Listesi***********************");
            Done.listToCarts();

        }












        public void showAllPerson()
        {
            Console.WriteLine("------Kişiler------");
            foreach (Person person in people.Values)
            {
                Console.WriteLine("Ad: " + person.Name);
                Console.WriteLine("Soyad:  " + person.SurName);
                Console.WriteLine("ID:  " + person.ID);
                Console.WriteLine("-------------------");
            }
        }



    }
}
