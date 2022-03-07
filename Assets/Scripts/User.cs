using System;

[Serializable]
public class User
{
    public int id;
    public string username;
    public string email;
    public string email_verified_at;
    public int account_number;
    public int card_count;
    public int fighter_count;
    public int level;
    public int admin;
    public int banned;

    public User(int id, string username, string email, string email_verified_at,
        int account_number, int card_count, int fighter_count, int level, int admin, int banned)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.email_verified_at = email_verified_at;
        this.account_number = account_number;
        this.card_count = card_count;
        this.fighter_count = fighter_count;
        this.level = level;
        this.admin = admin;
        this.banned = banned;
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}.",
            id, username, email, email_verified_at, account_number,
            card_count, fighter_count, level, admin, banned);
    }
}
