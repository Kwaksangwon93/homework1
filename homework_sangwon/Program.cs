namespace homework_sangwon
{
    internal class Program
    {

        class Item
        {
            private string type;
            private string name;
            private bool equip;
            private int ap { get; set; }
            private int dp { get; set; }
            private int hp { get; set; }
            private int gold;
            private string description;
            private bool isBuy;


            public Item(string type, string name, int ap, int dp, int gold, string description)
            {
                this.type = type;
                this.name = name;
                this.equip = false;
                this.ap = ap;
                this.dp = dp;
                this.hp = hp;
                this.gold = gold;
                this.description = description;
                this.isBuy = false;
            }

            public bool GetIsBuy()
            {
                return this.isBuy;
            }

            public void ToggleIsBuy(Character character)
            {
                if (this.isBuy == true)
                {
                    this.isBuy = false;
                }
                else if (this.isBuy == false)
                {
                    if (character.GetGold() >= this.gold)
                    {
                        this.isBuy = true;
                        character.ItemToInv(this);
                        Console.WriteLine("　구매 완료!");
                        character.UseGold(this.gold);
                    }
                    else if (character.GetGold() < this.gold)
                    {
                        Console.WriteLine("　Gold 가 부족합니다...");
                    }

                }
            }

            public bool GetEquipState()
            {
                return this.equip;
            }

            public void ToggleEquipState(Character character)
            {
                if (this.equip == true)
                {
                    this.equip = false;
                    this.UnequipItem(character);
                }
                else if (this.equip == false)
                {
                    this.equip = true;
                    this.EquipItem(character);
                }
            }

            public void PrintItemShop()
            {
                Console.Write("- ");
                Console.Write(this.name);
                Console.Write("\t| ");
                if (this.ap != 0)
                {
                    Console.Write("공격력 + {0}", this.ap);
                    Console.Write("\t| ");
                }
                if (this.dp != 0)
                {
                    Console.Write("방어력 + {0}", this.dp);
                    Console.Write("\t| ");
                }
                Console.Write("{0}\t| ", this.description);
                if (this.isBuy != true)
                {
                    Console.WriteLine("{0} G", this.gold);
                }
                else if (this.isBuy == true)
                {
                    Console.WriteLine("　구매완료");
                }
            }

            public void PrintItemInv()
            {
                Console.Write("- ");
                if (this.equip == true)
                {
                    Console.Write("[E]");
                }
                Console.Write(this.name);
                Console.Write("\t| ");
                if (this.ap != 0)
                {
                    Console.Write("공격력 + {0}", this.ap);
                    Console.Write("\t| ");
                }
                if (this.dp != 0)
                {
                    Console.Write("방어력 + {0}", this.dp);
                    Console.Write("\t| ");
                }
                Console.WriteLine(this.description);
            }



            public void EquipItem(Character character)
            {
                if (this.ap != 0)
                {
                    character.EquipItemAp(this.ap);
                }
                if (this.dp != 0)
                {
                    character.EquipItemDp(this.dp);
                }
            }
            public void UnequipItem(Character character)
            {
                if (this.ap != 0)
                {
                    character.UnequipItemAp(this.ap);
                }
                if (this.dp != 0)
                {
                    character.UnequipItemDp(this.dp);
                }
            }
        }

        class Character
        {
            private int level { get; set; }
            private string name { get; set; }
            private string job { get; set; }
            private int ap { get; set; }
            private int dp { get; set; }
            private int hp { get; set; }
            private int gold { get; set; }
            private List<Item> inventory;
            private int itemAp;
            private int itemDp;
            private int itemHp;
            private List<Item> shop;

            public Character(string name, string job)
            {
                this.level = 1;
                this.name = name;
                this.job = job;
                this.ap = 10;
                this.dp = 5;
                this.hp = 100;
                this.gold = 1500;
                this.inventory = new List<Item>();
                this.itemAp = 0;
                this.itemDp = 0;
                this.itemHp = 0;
                this.shop = new List<Item>();
            }

            public void EquipItemAp(int ap)
            {
                this.itemAp += ap;
            }
            public void UnequipItemAp(int ap)
            {
                this.itemAp -= ap;
            }
            public void EquipItemDp(int dp)
            {
                this.itemDp += dp;
            }
            public void UnequipItemDp(int dp)
            {
                this.itemDp -= dp;
            }
            
            public void Status()
            {
                Console.Clear();
                Console.WriteLine("────────────────────────────────────────────────────────────");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("　<상 태 보 기>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("　캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("　닉네임 : {0}", this.name);
                Console.WriteLine("　Lv. {0}", this.level);
                Console.WriteLine("　직업 : {0}", this.job);
                Console.Write("　공격력 : {0}", this.ap + this.itemAp);
                if (this.itemAp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemAp);
                }
                else if (this.itemAp == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("　방어력 : {0}", this.dp + this.itemDp);
                if (this.itemDp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemDp);
                }
                else if (this.itemDp == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("　체력 : {0}", this.hp + this.itemHp);
                if (this.itemHp != 0)
                {
                    Console.WriteLine(" (+{0})", this.itemHp);
                }
                else if (this.itemHp == 0)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("　골드 : {0}", this.gold);
                Console.WriteLine();

                Console.WriteLine("　0. 나가기");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("　원하시는 행동을 입력해주세요.");
                while (true)
                {
                    Console.WriteLine("　>> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("────────────────────────────────────────────────────────────");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "0":
                            return;
                        default:
                            Console.WriteLine("　잘못된 입력입니다. 나가려면 0을 입력하세요.");
                            break;

                    }
                }
            }
            
            public void Inventory()
            {
                Console.Clear();
                Console.WriteLine("────────────────────────────────────────────────────────────");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("　<인 벤 토 리>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("　보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("　[아이템 목록]");
                this.PrintInv();
                Console.WriteLine();

                Console.WriteLine("　1. 장착 관리");
                Console.WriteLine("　0. 나가기");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("　원하시는 행동을 입력해주세요.");
                Console.WriteLine("　>>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("────────────────────────────────────────────────────────────");
                while (true)
                {
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "0":
                            return;
                        case "1":
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("────────────────────────────────────────────────────────────");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("　<인 벤 토 리 - 장 착 관 리>");
                                Console.ForegroundColor = ConsoleColor.White;
                                if (inventory == null)
                                {
                                    Console.WriteLine("　아이템이 없습니다.");
                                    break;
                                }
                                else
                                {

                                    this.PrintEquip();
                                    Console.WriteLine();
                                    Console.WriteLine("　0. 나가기");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("　원하시는 항목을 입력해주세요.");
                                    Console.WriteLine("　>> ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("────────────────────────────────────────────────────────────");
                                    string num2 = Console.ReadLine();
                                    switch (num2)
                                    {
                                        case "0":
                                            return;
                                        default:

                                            int index = int.Parse(num2);
                                            if (index <= inventory.Count)
                                            {
                                                bool temp = inventory[index - 1].GetEquipState();
                                                inventory[index - 1].ToggleEquipState(this);
                                                if (temp == false)
                                                {
                                                    Console.WriteLine("　장착 되었습니다.");
                                                    Thread.Sleep(500);
                                                }                                                
                                                else if (temp == true)
                                                {
                                                    Console.WriteLine("　해제 되었습니다.");
                                                    Thread.Sleep(500);
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("　잘못된 입력입니다.");
                                                Thread.Sleep(500);
                                                break;
                                            }
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("　잘못된 입력입니다. 나가려면 0을 입력하세요.");
                            break;

                    }
                }
            }

            public void Shop()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("────────────────────────────────────────────────────────────");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("　<상 점>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("　필요한 아이템을 구매할 수 있는 상점입니다.");
                    Console.WriteLine();
                    Console.WriteLine("　[보유 골드]");
                    Console.WriteLine("　{0} G", this.gold);
                    Console.WriteLine();
                    Console.WriteLine("　[아이템 목록]");
                    this.PrintShop();
                    Console.WriteLine();
                    Console.WriteLine("　1. 아이템 구매");
                    Console.WriteLine("　0. 나가기");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("　원하시는 행동을 입력해주세요.");
                    Console.WriteLine("　>> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("────────────────────────────────────────────────────────────");
                    string num = Console.ReadLine();
                    switch (num)
                    {
                        case "1":
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("────────────────────────────────────────────────────────────");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("　<상 점 - 아 이 템 구 매>");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("　필요한 아이템을 구매할 수 있는 상점입니다.");
                                Console.WriteLine();
                                Console.WriteLine("　[보유 골드]");
                                Console.WriteLine("　{0} G", this.gold);
                                Console.WriteLine();
                                Console.WriteLine("　[아이템 목록]");
                                this.PrintBuy();
                                Console.WriteLine();
                                Console.WriteLine("　0. 나가기");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("　원하시는 항목을 입력해주세요.");
                                Console.WriteLine("　>> ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("────────────────────────────────────────────────────────────");
                                string num2 = Console.ReadLine();
                                int index = int.Parse(num2);
                                if (index <= shop.Count && index != 0)
                                {
                                    bool temp = shop[index - 1].GetIsBuy();
                                    if (temp == false)
                                    {
                                        shop[index - 1].ToggleIsBuy(this);
                                        Thread.Sleep(500);
                                    }
                                    else if (temp == true)
                                    {
                                        Console.WriteLine("　이미 구매한 아이템입니다.");
                                        Thread.Sleep(500);
                                    }
                                    break;
                                }
                                else if (index == 0)
                                {
                                    Console.WriteLine("　상점메뉴로 돌아갑니다.");
                                    Thread.Sleep(500);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("　잘못된 입력입니다.");
                                    Thread.Sleep(500);
                                }
                            }
                            break;

                        case "0":
                            return;
                        default:
                            Console.WriteLine("　잘못된 입력입니다.");
                            Thread.Sleep(500);
                            break;
                    }


                }
            }

            public void PrintShop()
            {
                if (shop != null)
                {
                    for (int i = 0; i < shop.Count; i++)
                    {
                        shop[i].PrintItemShop();
                    }

                }
            }
            public void PrintBuy()
            {
                if (shop != null)
                {
                    for (int i = 0; i < shop.Count; i++)
                    {
                        Console.Write("{0}. ", i + 1);
                        shop[i].PrintItemShop();
                    }

                }
            }

            public void PrintInv()
            {
                if (inventory != null)
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        inventory[i].PrintItemInv();
                    }

                }
            }
            public void PrintEquip()
            {
                if (inventory != null)
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.Write("{0}. ", i + 1);
                        inventory[i].PrintItemInv();
                    }

                }
            }

            public void UseGold(int gold)
            {
                this.gold -= gold;
            }

            public void GainGold(int gold)
            {
                this.gold += gold;
            }

            public int GetGold()
            {
                return this.gold;
            }

            public void ItemToInv(Item item)
            {
                this.inventory.Add(item);
            }

            public void Init()
            {
                Item item1 = new Item("방어구", "상원이의 훈도시", 0, 3, 500, "남이 입진 못할 것 같다.　　　　　　　 ");
                this.shop.Add(item1);
                Item item2 = new Item("방어구", "성훈이의 유카타", 0, 6, 1500, "살짝 풀어헤친 모습이 보기 좋진 않다.　　　");
                this.shop.Add(item2);
                Item item3 = new Item("방어구", "은수님의 기모노", 0, 10, 2500, "고풍스러운 느낌이 물씬 풍겨온다.　　　");
                this.shop.Add(item3);
                Item item4 = new Item("방어구", "하람이의 투명망토", 0, 1, 10000, "보이지 않는 만큼 방어력도 잃은 듯 하다.");
                this.shop.Add(item4);
                Item item5 = new Item("무기", "상원이의 주먹도끼", 3, 0, 1000, "돌은 마구 으깨놓은 모양새다. 맞으면 아프긴 할 것 같다.");
                this.shop.Add(item5);
                Item item6 = new Item("무기", "성훈이의 빗살무늬토기", 8, 0, 3500, "저건 애초에 무기가 아니지... 윽... 생각보다 아프다.");
                this.shop.Add(item6);
                Item item7 = new Item("무기", "은수님의 청동검", 13, 0, 1500, "유일하게 정상적인 무기다.");
                this.shop.Add(item7);
                Item item8 = new Item("무기", "하람이의 에어건", 1, 0, 10000, "바람이 날아오긴 하지만 아프지 않다.");
                this.shop.Add(item8);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("────────────────────────────────────────────────────────────");
            Console.WriteLine("");
            Console.Write("　　　　　　　　　　　　");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("▲    ▲");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("　　　　　　　　　　　　　　");
            Console.Write("　　　　　　　　　　 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("＼(");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("＠");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("^∇^");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("＠");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(") ノ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.Write("　　　　　　　　");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Welcome");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" to");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" the");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" 스파르타");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" 마을");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("　　　　　　　　");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("　　　　　　　");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Game Start ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": Player의 이름을 입력하세요.　　　　　　");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("────────────────────────────────────────────────────────────");
            string name = Console.ReadLine();
            Character character = new Character(name, "전사");
            character.Init();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("────────────────────────────────────────────────────────────");
                Console.WriteLine("　스파르타 마을에 오신 여러분 환영합니다!!");
                Console.WriteLine("　이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("　1. 상 태 보 기");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("　2. 인 벤 토 리");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("　3. 상 점");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("　0. 게 임 끝 내 기");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("　원하시는 행동을 입력해주세요.");
                Console.WriteLine("　>>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("────────────────────────────────────────────────────────────");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        character.Status();
                        break;
                    case "2":
                        character.Inventory();
                        break;
                    case "3":
                        character.Shop();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("　게임을 종료합니다.");
                        return;
                    default:
                        Console.WriteLine("　잘못된 입력입니다.");
                        break;

                }
            }
        }
    }
}

// 위 코드는 C05조 김성훈님의 코드를 기반으로 제작됨