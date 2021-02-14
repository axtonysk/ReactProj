﻿// <auto-generated />
using LayoutWebAPi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LayoutWebAPi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210117084839_AddedDefaultValues")]
    partial class AddedDefaultValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("LayoutWebAPi.Models.Layer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_available")
                        .HasColumnType("boolean");

                    b.Property<int>("layer_level_no")
                        .HasColumnType("integer");

                    b.Property<int>("layout_object_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("layout_object_id");

                    b.ToTable("layers");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.LayoutObject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_rack")
                        .HasColumnType("boolean");

                    b.Property<int>("module_id")
                        .HasColumnType("integer");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("module_id");

                    b.ToTable("layout_objects");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Module", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_available")
                        .HasColumnType("boolean");

                    b.Property<string>("layout_name")
                        .HasColumnType("text");

                    b.Property<float>("length")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("warehouse_id")
                        .HasColumnType("integer");

                    b.Property<float>("width")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("warehouse_id");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Properties", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<float>("height")
                        .HasColumnType("real");

                    b.Property<int>("layout_object_id")
                        .HasColumnType("integer");

                    b.Property<float>("max_height")
                        .HasColumnType("real");

                    b.Property<float>("max_width")
                        .HasColumnType("real");

                    b.Property<float>("min_height")
                        .HasColumnType("real");

                    b.Property<float>("min_width")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<float>("width")
                        .HasColumnType("real");

                    b.Property<float>("x_axis")
                        .HasColumnType("real");

                    b.Property<float>("y_axis")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("layout_object_id")
                        .IsUnique();

                    b.ToTable("properties");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Warehouse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("display_value")
                        .HasColumnType("text");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_available")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("warehouses");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Layer", b =>
                {
                    b.HasOne("LayoutWebAPi.Models.LayoutObject", "layout_object")
                        .WithMany("layers")
                        .HasForeignKey("layout_object_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("layout_object");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.LayoutObject", b =>
                {
                    b.HasOne("LayoutWebAPi.Models.Module", "module")
                        .WithMany("layout_objects")
                        .HasForeignKey("module_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("module");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Module", b =>
                {
                    b.HasOne("LayoutWebAPi.Models.Warehouse", "warehouse")
                        .WithMany("modules")
                        .HasForeignKey("warehouse_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("warehouse");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Properties", b =>
                {
                    b.HasOne("LayoutWebAPi.Models.LayoutObject", "layout_object")
                        .WithOne("properties")
                        .HasForeignKey("LayoutWebAPi.Models.Properties", "layout_object_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("layout_object");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.LayoutObject", b =>
                {
                    b.Navigation("layers");

                    b.Navigation("properties");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Module", b =>
                {
                    b.Navigation("layout_objects");
                });

            modelBuilder.Entity("LayoutWebAPi.Models.Warehouse", b =>
                {
                    b.Navigation("modules");
                });
#pragma warning restore 612, 618
        }
    }
}
