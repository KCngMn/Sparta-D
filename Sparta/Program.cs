namespace Sparta
{



    internal class Program
    {
        public class Player
        {
            public int Level { get; set; }
            public string Name { get; }
            public string Class { get; }
            public int Attack { get; set; }
            public int Sheild { get; set; }
            public int Health { get; set; }
            public int Money { get; set; }
            public bool IsEquipWeapon { get; set; }
            public bool IsEquipArmor { get; set; }

            public List<Item> MyItems { get; set; }

            public Player(string name)
            {
                Level = 1;
                Name = name;
                Class = "전사";
                Attack = 10;
                Sheild = 5;
                Health = 100;
                Money = 1500;
                MyItems = new List<Item>();

                IsEquipWeapon = false;
                IsEquipArmor = false;
            }
        }

        public interface Item
        {
            string Name { get; }
            int Id { get; }
            int Gold { get; }
            string Info { get; }
            public int Shield { get; }
            public int Attack { get; }
            public bool I_buy { get; set; }
            public bool I_equip { get; set; }
            void ItemBuy(Player player);

        }
        public class ItemIdx
        {
            public List<Item> Itemidx { get; set; }
            public bool Isbuy { get; set; }

            public ItemIdx()
            {
                Itemidx = new List<Item>() { new ItemList() { Id = 1, Name = "수련자 갑옷",  Info = "수련에 도움을 주는 갑옷입니다.",Shield = 5,
                Attack = 0,Gold = 1000,I_buy = false,I_equip = false, },
                new ItemList() { Id = 2, Name = "무쇠갑옷",  Info = "무쇠로 만들어져 튼튼한 갑옷입니다.",Shield = 9,
                Attack = 0,Gold = 1200,I_buy = false,I_equip = false, },
                new ItemList() { Id = 3, Name = "스파르타의 갑옷",  Info = "스파르타의 전사들이 사용했다는  전설의 갑옷입니다",Shield = 15,
                Attack = 0,Gold = 3500,I_buy = false,I_equip = false, },
                new ItemList() { Id = 4, Name = "낡은검",  Info = "쉽게  볼 수 있는 낡은 검 입니다.",Shield = 0,
                Attack = 2,Gold = 600,I_buy = false,I_equip = false, },
                new ItemList() { Id = 5, Name = "청동 도끼",  Info = "어디선가 사용됐던거  같은 도끼입니다..",Shield = 0,
                Attack = 5,Gold = 1500,I_buy = false,I_equip = false, },
                new ItemList() { Id = 6, Name = "스파르타의 창",  Info = "스파르타의 전사들이  사용했다는 전설의  창입니다",Shield = 0,
                Attack = 7,Gold = 3500,I_buy = false,I_equip = false, }};



                Isbuy = false;
            }
        }
        // 아이템 리스트에 들어갈  클래스 생성
        public class ItemList : Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Info { get; set; }
            public int Shield { get; set; }
            public int Attack { get; set; }
            public int Gold { get; set; }
            public bool I_buy { get; set; }
            public bool I_equip { get; set; }

            public ItemList()
            {
                Id = 1;
                Name = "수련자 갑옷";
                Info = "수련에 도움을 주는 갑옷입니다.";
                Shield = 5;
                Attack = 0;
                Gold = 1000;
                I_buy = false;
                I_equip = false;
            }
            public void ItemBuy(Player player)
            {
              
        }

        // 시작시  화면
        public static void Lobby(Player player, ItemIdx itemidx)
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳애소 던전으로 들어가기전 활동을 할수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤 토리");
            Console.WriteLine("3. 상점\n ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>>");
            string input = Console.ReadLine();
            //각각의 화면을 호출하는 함수

            if (input == "1")
            {
                State(player, itemidx);
            }
            if (input == "2")
            {
                InvenLobby(player, itemidx);
            }
            else if (input == "3")
            {
                ShopLobby(player, itemidx);
            }
            else
            {
                Miss();
                Lobby(player, itemidx);
            }


        }

        public static void Miss()
        {
            Console.Clear();
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
        }
        public static void State(Player player, ItemIdx Itemidx)
        {
            int addArmor = 0;
            int addAttack = 0;

            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv.{0:00}\n", player.Level);
            if (player.MyItems.Count != 0)
            {
                // 장착된 아이템 찾기
                Item selectItem = player.MyItems.Find(item => item.I_equip == true);
                foreach (var item in player.MyItems)
                {
                    if (item.I_equip)
                    {
                        if (item.Id >= 1 && item.Id <= 3)
                        {
                            player.IsEquipArmor = true;
                            addArmor += item.Shield;
                        }
                        else
                        {
                            player.IsEquipWeapon = true;
                            addAttack += item.Attack;
                        }
                    }
                }
            }

            if (!player.IsEquipWeapon)
                Console.WriteLine("공격력 : " + player.Attack);
            else
                Console.WriteLine("공격력 : " + player.Attack + " (+{0})", addAttack);
            if (!player.IsEquipArmor)
                Console.WriteLine("방어력 : " + player.Sheild);
            else
                Console.WriteLine("방어력 : " + player.Sheild + " (+{0})", addArmor);

            Console.WriteLine("체력 : {0}\n", player.Health);
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Gold : {0}", player.Money);
            if (input == 0)
            {
                Lobby(player, Itemidx);
            }
        }
        public static void InvenLobby(Player player, ItemIdx itemidx)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 볼 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine("1.장착관리");
            Console.WriteLine("0.나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("\n");
            Console.Write(">>>");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 0:
                    Lobby(player, itemidx);
                    break;
                case 1:
                    Equip(player, itemidx);
                    break;
                default:
                    Miss();
                    Inventory(player, itemidx);
                    break;
            }
        }


        public static void ShopLobby(Player player, ItemIdx Itemidx)
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을수 있는 상점입니다.\n");
            Console.WriteLine("[보유골드]\n");
            Console.WriteLine($"{player.Money} G");
            Console.WriteLine("[아이템 목록]\n");
            if (Itemidx != null)
            {
                int i = 1;
                // 아이템 목록 불러오기
                foreach (var item in Itemidx.Itemidx)
                {
                    if (!Itemidx.Isbuy)
                    {
                        if (!item.I_buy)
                        {
                            if (item.Attack == 0)
                                Console.WriteLine($"- {item.Name}   | 방어력 +{item.Shield} | {item.Info}   | {item.Gold} G");

                            else
                                Console.WriteLine($"- {item.Name}   | 공격력 +{item.Attack}   | {item.Info}   | {item.Gold} G");
                        }
                        else
                        {
                            if (item.Attack == 0)
                                Console.WriteLine($"- {item.Name}   | 방어력 +{item.Shield}   | {item.Info}   |  구매완료");
                            else
                                Console.WriteLine($"- {item.Name}   | 공격력 +{item.Attack}   | {item.Info}   |  구매완료");
                        }
                    }
                    else
                    {
                        if (!item.I_buy)
                        {
                            if (item.Attack == 0)
                                Console.WriteLine($"- {i++} {item.Name}   | 방어력 +{item.Shield}   | {item.Info}   | {item.Gold} G");
                            else
                                Console.WriteLine($"- {i++} {item.Name}   | 공격력 +{item.Attack}   | {item.Info}   | {item.Gold} G");
                        }
                        else
                        {
                            if (item.Attack == 0)
                                Console.WriteLine($"- {i++} {item.Name}   | 방어력 +{item.Shield}   | {item.Info}   |  구매완료");
                            else
                                Console.WriteLine($"- {i++} {item.Name}   | 공격력 +{item.Attack}   | {item.Info}   |  구매완료");
                        }
                    }
                }
            }

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("\n");
            Console.Write(">>>");
            int input = int.Parse(Console.ReadLine());

            if (!Itemidx.Isbuy)
            {
                switch (input)
                {
                    case 0:
                        Lobby(player, Itemidx);
                        break;
                    case 1:
                        Itemidx.Isbuy = true;
                        ShopLobby(player, Itemidx);
                        break;
                    default:
                        Miss();
                        ShopLobby(player, Itemidx);
                        break;
                }
            }
            else
            {
                if (input == 0)
                {
                    Itemidx.Isbuy = false;
                    Lobby(player, Itemidx);
                }
                else
                {
                    Item ChoiceItm = Itemidx.Itemidx.Find(item => item.Id == input);
                    if (ChoiceItm != null)
                    {
                        //중복 구매 막기 구현  
                        if (!ChoiceItm.I_buy)
                        {
                            ChoiceItm.ItemBuy(player);
                            player.MyItems.Add(ChoiceItm);
                            Thread.Sleep(1000);
                            ShopLobby(player, Itemidx);
                        }
                        else
                        {
                            Console.WriteLine("이미 구매한 아이템 입니다.");
                            Thread.Sleep(1000);
                            ShopLobby(player, Itemidx);
                        }
                    }
                    else
                    {
                        Miss();
                        ShopLobby(player, Itemidx);
                    }
                }
            }
        }
        public static void Inventory(Player player, ItemIdx Itemidx)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 0:
                    Lobby(player, Itemidx);
                    break;
                case 1:
                    Equip(player, Itemidx);
                    break;
                default:
                    Miss();
                    Inventory(player, Itemidx);
                    break;
            }
        }
        public static void Equip(Player player, ItemIdx Itemidx)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            if (player.MyItems.Count != 0)
            {
                foreach (var item in player.MyItems)
                {
                    if (!item.I_equip)
                    {
                        if (item.Attack == 0)
                            Console.WriteLine($"- {item.Id} {item.Name}   | 방어력 +{item.Shield}   | {item.Info}");
                        else
                            Console.WriteLine($"- {item.Id} {item.Name}   | 공격력 +{item.Attack}   | {item.Info}");
                    }
                    else
                    {
                        if (item.Attack == 0)
                            Console.WriteLine($"- {item.Id} [E] {item.Name}   | 방어력 +{item.Shield}   | {item.Info}");
                        else
                            Console.WriteLine($"- {item.Id} [E] {item.Name}   | 공격력 +{item.Attack}   | {item.Info}");
                    }
                }
            }
            else
                Console.WriteLine("보유하고 있는 장비가 없습니다.\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Lobby(player, Itemidx);
            }
            else
            {
                Item selectItem = player.MyItems.Find(item => item.Id == input);
                if (selectItem != null)
                {
                    if (!selectItem.I_equip)
                    {
                        selectItem.I_equip = true;
                        Equip(player, Itemidx);
                    }
                    else
                    {
                        selectItem.I_equip = false;
                        Equip(player, Itemidx);
                    }
                }
                else
                {
                    Miss();
                    Equip(player, Itemidx);
                }
            }
        }

        static void Main(string[] args)
        {
            ItemIdx itemidx = new ItemIdx();
            Player player = new Player("Player");
            Lobby(player, itemidx);
        }
    }
}





