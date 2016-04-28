namespace FoodHunterAlpha.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<menu_category> menu_category { get; set; }
        public virtual DbSet<menu_combo_item> menu_combo_item { get; set; }
        public virtual DbSet<menu_item> menu_item { get; set; }
        public virtual DbSet<menu_item_option> menu_item_option { get; set; }
        public virtual DbSet<order_header> order_header { get; set; }
        public virtual DbSet<order_item> order_item { get; set; }
        public virtual DbSet<rest_cust_details> rest_cust_details { get; set; }
        public virtual DbSet<rest_cust_item_price> rest_cust_item_price { get; set; }
        public virtual DbSet<rest_table> rest_table { get; set; }
        public virtual DbSet<restaurant> restaurants { get; set; }
        public virtual DbSet<sales_rep> sales_rep { get; set; }
        public virtual DbSet<rest_cust_payment> rest_cust_payment { get; set; }
        public virtual DbSet<rest_hours> rest_hours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.cust_name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_password)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_phone)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_address)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_apartment)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_street_num)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_street_name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.last_ip_addr)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_suburb)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_city)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_country)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_region)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cust_country_code)
                .IsUnicode(false);

            modelBuilder.Entity<menu_category>()
                .Property(e => e.cate_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_category>()
                .Property(e => e.second_cate_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_category>()
                .Property(e => e.cate_note)
                .IsUnicode(false);

            modelBuilder.Entity<menu_combo_item>()
                .Property(e => e.combo_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.item_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.second_item_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.item_note)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.photo_loc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.thumb_loc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item>()
                .Property(e => e.item_label)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item_option>()
                .Property(e => e.option_group_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item_option>()
                .Property(e => e.option_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item_option>()
                .Property(e => e.second_option_desc)
                .IsUnicode(false);

            modelBuilder.Entity<menu_item_option>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.order_ip_addr)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.disc_comment)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.order_type)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.order_status)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.table_number)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_note)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_name)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_phone)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_apartment)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_address)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.cust_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.user_agent)
                .IsUnicode(false);

            modelBuilder.Entity<order_header>()
                .Property(e => e.sync_batch_id)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.item_desc)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.second_item_desc)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.option_code)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.sync_batch_id)
                .IsUnicode(false);

            modelBuilder.Entity<rest_cust_details>()
                .Property(e => e.cust_email)
                .IsUnicode(false);

            modelBuilder.Entity<rest_cust_details>()
                .Property(e => e.cust_name)
                .IsUnicode(false);

            modelBuilder.Entity<rest_cust_details>()
                .Property(e => e.cust_phone)
                .IsUnicode(false);

            modelBuilder.Entity<rest_cust_details>()
                .Property(e => e.cust_address)
                .IsUnicode(false);

            modelBuilder.Entity<rest_cust_details>()
                .Property(e => e.cust_apartment)
                .IsUnicode(false);

            modelBuilder.Entity<rest_table>()
                .Property(e => e.table_number)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.rest_name)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.second_rest_name)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.rest_desc)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.apartment)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.suburb)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.country_code)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.currency_symbol)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.currency_code)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.phone_num)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.logo_loc)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.login_email)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.login_password)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.last_ip_addr)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.online_payment_charge_type)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.order_notice_email)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.order_notice_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.activation_key)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.rest_category)
                .IsUnicode(false);

            modelBuilder.Entity<restaurant>()
                .Property(e => e.delivery_term)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_code)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_family_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_surname)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_apartment)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_city)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_country)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_email)
                .IsUnicode(false);

            modelBuilder.Entity<sales_rep>()
                .Property(e => e.rep_password)
                .IsUnicode(false);
        }
    }
}
